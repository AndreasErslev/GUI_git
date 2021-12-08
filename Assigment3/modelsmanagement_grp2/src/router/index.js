import { createRouter, createWebHashHistory } from "vue-router";

const routes = [
  {
    path: "/",
    name: "Home",
    component: () => import("../views/Home.vue"),
  },
  {
    path: "/about",
    name: "About",
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () =>
      import(/* webpackChunkName: "about" */ "../views/About.vue"),
  },
  {
    path: "/CreateManager",
    name: "Create a new Manager",
    component: () => import("../views/CreateManager.vue"),
  },
  {
    path: "/CreateModel",
    name: "Create a new Model",
    component: () => import("../views/CreateModel.vue"),
  },
  {
    path: "/Login",
    name: "Login",
    component: () => import("../views/Login.vue"),
  },
  {
    path: "/AddJob",
    name: "Add Job",
    component: () => import("../views/AddJob.vue"),
  },
  {
    path: "/JobsManager",
    name: "Jobs for manager",
    component: () => import("../views/JobsManager.vue"),
  },
  {
    path: "/JobsModel",
    name: "Jobs for model",
    component: () => import("../views/JobsModel.vue"),
  },
  {
    path: "/Expences",
    name: "Expences",
    component: () => import("../views/Expences.vue"),
  },
];

const router = createRouter({
  history: createWebHashHistory(),
  routes,
});

export default router;
