<template>
  <nav>
    <RouterLink to="/" id="logo_url">
      <img :src="logo" id="logo" :alt="alt">
    </RouterLink>
    <RouterLink to="/">Home</RouterLink> |
    <RouterLink to="/orders">Pedidos</RouterLink>
    
  </nav>
 
</template>

<script>
export default {
  props: ['logo', 'alt'],

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

nav a{
  color: #FCBA03;
  text-decoration: none;
  margin: 12px;
  transition: .5s;
}
nav a:hover{
  color: #FFF;
}
</style>