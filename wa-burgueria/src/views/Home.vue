<template>
  <Navbar :logo="logoUrl" :alt="app_name" @login="handleLogin" />
  <Banner />
  <div class="main-container">
    <h1>Aqui será a Home Page:</h1>
  </div>
</template>

<script>
import useModal from "@/hooks/useModal";

import Navbar from "@/components/Navbar.vue";
import Banner from "@/components/Banner.vue";
export default {
  components: {
    Navbar,
    Banner,
  },
  data() {
    return {
      logoUrl: "/img/logo.png",
      app_name: "Make Your Burger",
    };
  },

  setup(){
    const modal = useModal();

    function handleLogin(){
      modal.open({
        component: "ModalLogin"
      })
    }

    return {
      handleLogin
    }
  }
};
</script>