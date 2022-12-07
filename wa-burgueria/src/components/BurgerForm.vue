<template>
  <div>
    <div>
      <form id="burger-form" @submit.prevent="handleCreateBurger">
        <div class="input-container">
          <label for="clientName">Nome do cliente:</label>
          <input
            type="text"
            id="clientName"
            name="name"
            v-model="state.name"
            placeholder="Digite o seu nome completo"
          />
          <div class="input-container">
            <label for="bread">Escolha o tipo de pão do seu Burger:</label>
            <select name="bread" id="bread" v-model="state.bread">
              <option value="">Selecione o seu pão</option>
              <option
                v-for="bread in state.breads"
                :key="bread.id"
                :value="bread.tipo"
              >
                {{ bread.tipo }}
              </option>
            </select>
          </div>
          <div class="input-container">
            <label for="bread">Escolha a carne do seu Burger:</label>
            <select name="bread" id="bread" v-model="state.meat">
              <option value="">Selecione a sua carne</option>
              <option
                v-for="meat in state.meats"
                :key="meat.id"
                :value="meat.tipo"
              >
                {{ meat.tipo }}
              </option>
            </select>
          </div>
          <div id="extras-container" class="input-container">
            <label for="extras" id="extras-title"
              >Selecione os opcionais:</label
            >
            <div
              class="checkbox-container"
              v-for="extra in state.extrasData"
              :key="extra.id"
            >
              <input
                type="checkbox"
                name="extras"
                v-model="state.extras"
                :value="extra.tipo"
              />
              <span>{{ extra.tipo }}</span>
            </div>
          </div>
          <div id="extras-container" class="input-container">
            <div class="input-container">
              <input
                type="submit"
                class="submit-btn"
                value="FINALIZAR SEU BURGER E PEDIDO!"
              />
            </div>
          </div>
        </div>
      </form>
    </div>
  </div>
</template>

<script>
import { onMounted, reactive } from "vue";

import Swal from "sweetalert2";
import router from "@/router";
import services from "@/services";
import delay from "@/utils/delay";

export default {
  setup() {
    const state = reactive({
      breads: null,
      meats: null,
      extrasData: null,
      name: "",
      bread: "",
      meat: "",
      extras: [],
    });

    async function getDataFromDataBase() {
      try {
        const { data, errors } = await services.ingredients.getIngredients();

        if (!errors) {
          state.breads = data.paes;
          state.meats = data.carnes;
          state.extrasData = data.opcionais;
          return;
        }
      } catch (error) {
        console.log(error);
        Swal.fire({
          icon: "error",
          iconColor: "#d33",
          title: "Oops...",
          text: "Ocorreu um erro, tente novamente!",
        });
      }
    }

    async function handleCreateBurger() {
      try {
        if(state.name === "" || state.meat === "" || state.bread === "" ){
          Swal.fire({
          icon: "error",
          iconColor: "#d33",
          title: "Oops...",
          confirmButtonColor: "#d33",
          text: "Há campos a serem preenchidos no seu pedido.",
        });
        return;
        }
        const { data } = await services.burgers.createOrder({
          nome: state.name,
          carne: state.meat,
          pao: state.bread,
          opcionais: state.extras,
          status: "Solicitado",
        });
        Swal.fire({
          position: "center",
          icon: "success",
          iconColor: "#20a345",
          title: `Pedido ${data.id} realizado com sucesso!`,
          showConfirmButton: false,
          timer: 2500,
        });
        state.name = "";
        state.meat = "";
        state.bread = "";
        state.extras = [];
        await delay(2500);
        router.push("/orders");
      } catch (error) {
        console.log(error);
      }
    }

    onMounted(() => {
      getDataFromDataBase();
    });

    return {
      state,
      handleCreateBurger,
    };
  },
};
</script>

<style scoped>
#burger-form {
  max-width: 400px;
  margin: 0 auto;
}

.input-container {
  display: flex;
  flex-direction: column;
  margin-bottom: 20px;
}

label {
  font-weight: bold;
  margin-bottom: 15px;
  color: #222;
  padding: 5px 10px;
  border-left: 4px solid #fcba03;
}

input,
select {
  padding: 5px 10px;
  width: 300px;
}

#extras-container {
  flex-direction: row;
  flex-wrap: wrap;
}

#extras-title {
  width: 100%;
}

.checkbox-container {
  display: flex;
  align-items: flex-start;
  width: 50%;
  margin-bottom: 20px;
}

.checkbox-container span,
.checkbox-container input {
  width: auto;
}

.checkbox-container span {
  margin-left: 6px;
  font-weight: bold;
}

.submit-btn {
  background-color: #222;
  color: #fcba03;
  font-weight: bold;
  border: 2px solid #222;
  padding: 10px;
  font-size: 16px;
  margin: 0 auto;
  cursor: pointer;
  border-radius: 4px;
  transition: 0.5s;
}

.submit-btn:hover {
  background-color: transparent;
  color: #222;
}
</style>