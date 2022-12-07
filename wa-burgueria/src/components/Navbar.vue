<template>
  <nav>
    <RouterLink to="/" id="logo_url">
      <img :src="logo" id="logo" :alt="alt" />
    </RouterLink>
    <button id="header-login-button" @click="() => emit('login')">
      Entrar
    </button>
    <button id="header-createaccount-button" @click="() => emit('')">
      Criar conta
    </button>
  </nav>
</template>

<script>
export default {
  props: ["logo", "alt"],

  setup(_, { emit }) {
    return { emit };
  },
};
</script>

<style scoped>
nav {
  background-color: #222;
  border-bottom: 4px solid #111;
  padding: 15px 50px;
  display: flex;
  justify-content: flex-end;
  align-items: center;
}

#logo_url {
  margin: auto;
  margin-left: 0;
}

#logo {
  width: 40px;
  height: 40px;
}

#header-login-button, #header-createaccount-button {
  padding: 24px 4px;
  font-weight: bold;
  font-size: 16px;
  background-color: transparent;
  color: #fcba03;
  border: 2px solid transparent;
  cursor: pointer;
}

nav a {
  color: #fcba03;
  text-decoration: none;
  margin: 12px;
  transition: 0.5s;
}
nav a:hover {
  color: #fff;
}
</style>