<template>
<ModalFactory />
  <router-view />
  <Footer />
</template>

<script>
import { watch } from "vue";
import { useRoute, useRouter } from "vue-router";
import services from "@/services";
import { setCurrentUser } from "@/store/user";

import ModalFactory from "@/components/ModalFactory";
import Footer from "@/components/Footer.vue";

export default {
  components: {
    ModalFactory,
    Footer,
  },
  
  setup() {
    const router = useRouter();
    const route = useRoute();

    watch(
      () => route.path,
      async () => {
        if (route.meta.requiresAuth) {
          const token = localStorage.getItem("token");
          if (!token) {
            router.push({ name: "Home" });
            return;
          }
          const { data } = await services.users.getMe();
          setCurrentUser(data);
        }
      }
    );
  },
};
</script>

<style>
* {
  font-family: "Roboto";
  padding: 0;
  margin: 0;
  box-sizing: border-box;
}

.main-container {
  margin: 50px;
  margin-left: 10px;
  min-height: 250px;
}

h1 {
  text-align: center;
  font-size: 42px;
  color: #222;
  margin-bottom: 30px;
  margin-right: 60px;
}
</style>