<template>
  <div v-if="state.burgers" id="burger-table">
    <div>
      <div id="burger-table-heading">
        <div class="order-id">#:</div>
        <div>Cliente:</div>
        <div>Pão:</div>
        <div>Carne:</div>
        <div>Opcionais:</div>
        <div>Ações:</div>
      </div>
    </div>
    <div id="burger-table-rows">
      <div
        class="burger-table-row"
        v-for="order in state.burgers"
        :key="order.id"
      >
        <div class="order-number">{{ order.id }}</div>
        <div>{{ order.nome }}</div>
        <div>{{ order.pao }}</div>
        <div>{{ order.carne }}</div>
        <div>
          <ul v-for="(extras, index) in order.opcionais" :key="index">
            <li>{{ extras }}</li>
          </ul>
        </div>
        <div>
          <select
            name="status"
            class="status"
            @click="state.token ? updateOrder(order.id): handleConfirmUpdateOrder(order.id)"
          >
            <option
              :value="status.tipo"
              v-for="status in state.status"
              :key="status.id"
              :selected="order.status == status.tipo"
            >
              {{ status.tipo }}
            </option>
          </select>
          <button @click="handleDeleteOrder(order.id)" class="delete-btn">
            Cancelar
          </button>
        </div>
      </div>
    </div>
  </div>
  <div v-else>
    <h2>Não há pedidos no momento!</h2>
  </div>
</template>

<script>
import { onMounted, reactive } from "vue";

import Swal from "sweetalert2";
import services from "@/services";
import delay from "@/utils/delay";

export default {
  setup() {
    const state = reactive({
      burgers: [],
      burger_id: null,
      status: [],
      statusUpdated: "",
      orderBeingDeleted: 0,
      orderBeingUpdated: 0,
      email: null,
      password: null,
      token: null
    });
    
    const token = localStorage.getItem("token");

    state.token = token;

    async function getOrders() {
      try {
        const { data } = await services.burgers.getBurgers();

        state.burgers = data;

        getStatus();
      } catch (error) {
        console.log(error);
      }
    }

    async function getStatus() {
      try {
        const { data } = await services.burgers.getOrderStatus();
        state.status = data;
      } catch (error) {
        console.log(error);
      }
    }

    async function handleConfirmDeleteOrder() {
      try {
        await services.burgers.deleteOrder(`${state.orderBeingDeleted}`);
        Swal.fire({
          position: "center",
          icon: "success",
          iconColor: "#20a345",
          title: `Pedido ${state.orderBeingDeleted} deletado com sucesso!`,
          showConfirmButton: false,
          timer: 2500,
        });
        await delay(2500);
        location.reload();
      } catch (error) {
        console.log(error);
      }
    }

    async function handleDeleteOrder(id) {
      state.orderBeingDeleted = id;
      Swal.fire({
        title: "Cancelar pedido?",
        text: "Essa ação é irreversível!",
        icon: "warning",
        iconColor: "#d33",
        showCancelButton: true,
        confirmButtonColor: "#d33",
        cancelButtonColor: "#222",
        cancelButtonText: "Manter pedido.",
        confirmButtonText: "Sim, cancelar pedido!",
      }).then((result) => {
        if (result.isConfirmed) {
          handleConfirmDeleteOrder(id);
        }
      });
    }

    async function handleConfirmUpdateOrder(id) {
      state.orderBeingUpdated = id;
      Swal.fire({
        title: "Acesso de administrador requerido",
        text: "Efetuar login, admin?",
        icon: "warning",
        iconColor: "#d33",
        showCancelButton: true,
        confirmButtonColor: "#d33",
        cancelButtonColor: "#222",
        cancelButtonText: "Cancelar",
        confirmButtonText: "Efetuar login",
      }).then((result) => {
        if(state.token === undefined){
          return;
        }
        if (result.isConfirmed) {
          handleAdminLogin(id);
        }
      });
    }

    async function handleAdminLogin(id) {
      try {
        state.orderBeingUpdated = id;
        Swal.fire({
          title: 'Login Form',
          html: `<input type="text" id="login" class="swal2-input" placeholder="Username">
          <input type="password" id="password" class="swal2-input" placeholder="Password">`,
          confirmButtonText: 'Sign in',
          focusConfirm: false,
          preConfirm: () => {
            const login = Swal.getPopup().querySelector('#login').value
            const password = Swal.getPopup().querySelector('#password').value
            if (!login || !password) {
              Swal.showValidationMessage(`Please enter login and password`)
            }
            state.email = login;
            state.password = password;
            return { login: login, password: password }
          }
        }).then()
          if (state.email === null || state.password === null){
          return;
        }
        const { data, errors } = await services.auth.login({
          email: state.email,
          password: state.password,
        });
        console.log("🔥🔥🔥", data);
        if (!errors) {
          localStorage.setItem("token", data.token);
          state.token = data.token;
          updateOrder(id);
        }
        Swal.fire({
          position: "center",
          icon: "success",
          iconColor: "#20a345",
          title: `Login ${state.email} efetuado com sucesso!`.trim(),
          showConfirmButton: false,
          timer: 2500,
        });
      } catch (error) {
        console.log(error);
      } 
    }

    async function updateOrder(id) {
      try {
        const option = event.target.value;

        const { data } = await services.burgers.updateOrder(id, option);

        Swal.fire({
          position: "center",
          icon: "success",
          iconColor: "#20a345",
          title: `Pedido ${data.id} foi atualizado para ${data.status}!`,
          showConfirmButton: false,
          timer: 2500,
        });
        await delay(2500);
        location.reload();
      } catch (error) {
        console.log(error);
      }
    }

    onMounted(() => {
      getOrders();
    });

    return {
      state,
      updateOrder,
      handleDeleteOrder,
      handleConfirmDeleteOrder,
      handleConfirmUpdateOrder,
    };
  },
};
</script>

<style scoped>
#burger-table {
  max-width: 1200px;
  margin: 0 auto;
}
#burger-table-heading,
#burger-table-rows,
.burger-table-row {
  display: flex;
  flex-wrap: wrap;
}
#burger-table-heading {
  font-weight: bold;
  padding: 12px;
  border-bottom: 3px solid #333;
}
.burger-table-row {
  width: 100%;
  padding: 12px;
  border-bottom: 1px solid #ccc;
}
#burger-table-heading div,
.burger-table-row div {
  width: 19%;
}
#burger-table-heading .order-id,
.burger-table-row .order-number {
  width: 5%;
}
select {
  padding: 12px 6px;
  margin-right: 12px;
}
.delete-btn {
  background-color: #222;
  color: #fcba03;
  font-weight: bold;
  border: 2px solid #222;
  padding: 10px;
  font-size: 16px;
  margin: 0 auto;
  cursor: pointer;
  transition: 0.5s;
}

.delete-btn:hover {
  background-color: transparent;
  color: #222;
}
</style>
