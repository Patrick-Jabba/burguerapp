<template>
  <div id="modal-login">
    <h1>Entre na sua conta</h1>

    <button @click="close" class="close-button">&times;</button>
  </div>

  <div class="form-div">
    <form @submit.prevent="handleSubmit">
      <label>
        <span class="">E-mail</span>
        <input
          id="email-field"
          v-model="state.email"
          type="email"
          placeholder="email@email.com"
        />
      </label>

      <label class="password-label">
        <span>Senha</span>
        <input
          id="password-field"
          v-model="state.password"
          type="password"
          placeholder="minhasenhasecreta"
        />
      </label>

      <div class="div-button-submit">
        <button
          id="submit-button"
          :disabled="state.isLoading"
          type="submit"
          :class="{ 'opacity-50': state.isLoading }"
          class="submit-button"
        >
          <span>ENTRAR</span>
        </button>
      </div>
    </form>
  </div>
</template>

<script>
import { reactive } from "vue";
import { setCurrentUser } from "@/store/user";
import { useRouter } from "vue-router";

import useModal from "@/hooks/useModal";
import services from "@/services";

import Swal from "sweetalert2";

export default {
  setup() {
    const router = useRouter();
    const modal = useModal();

    const state = reactive({
      isLoading: false,
      email: "",
      password: "",
      user: [],
    });

    async function handleSubmit() {
      try {
        const { users } = await services.auth.getMe();
        
        state.user = users.filter(user => {
          let exist = false;
          if(user.email === state.email && user.password === state.password){
            exist = true;
            console.log(user, 'cheguei aqui')
            return user;
          }
          if(!exist){
            Swal.fire({
              icon: "error",
              iconColor: "#d33",
              title: "Não há conta registrada para esse usuário",
              footer: '<a href="">Criar conta</a>',
            });
          } else {
            router.push({ path: "/order" });
            modal.close();
            setCurrentUser(state.user);
            return;
          }
        })

            console.log("🦩🦩🦩🦩🦩", state.user);
        console.log("🐬", users);
      } catch (error) {
        console.log(error);
      }
    }

    return {
      state,
      close: modal.close,
      handleSubmit,
    };
  },
};
</script>

<style scoped>
#modal-login {
  display: flex;
  justify-content: space-between;
}

h1 {
  font-size: 36px;
  font-weight: bold;
  color: #222;
}

.close-button {
  font-size: 36px;
  font-weight: bold;
  border: 2px solid transparent;
  background-color: white;
}
.div-button-submit {
  display: flex;
  align-items: center;
}
.submit-button {
  display: flex;
  padding: 32px 12px;
  margin-top: 40px;
  font-size: 24px;
  font-weight: bold;
  color: white;
  border: 2px solid transparent;
  background-color: white;
  cursor: pointer;
}

.form-div {
  margin-top: 64px;
}

label {
  display: block;
}

span {
  font-size: 18px;
  font-weight: bold;
  color: #222;
}

input {
  display: block;
  width: 100%;
  padding: 16px 12px;
  margin-top: 4px;
  font-size: 18px;
  background-color: #bbb;
  border-radius: 4px;
  border: 2px solid transparent;
}

.password-label {
  display: block;
  margin-top: 36px;
}
</style>
