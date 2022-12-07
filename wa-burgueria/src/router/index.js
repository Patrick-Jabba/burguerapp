import { createRouter, createWebHistory } from 'vue-router'

const Home = () => import("@/views/Home.vue");
const Order = () => import("@/views/Order.vue");
const Orders = () => import("@/views/Orders.vue");

const routes = [
  {
    path: '/',
    name: 'home',
    component: Home
  },
  {
    path: '/order',
    name: 'order',
    component: Order
  },
  {
    path: '/orders',
    name: 'orders',
    component: Orders
  }
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
