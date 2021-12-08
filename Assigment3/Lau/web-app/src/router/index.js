import Vue from "vue";
import VueRouter from "vue-router";
import decode from "@/shared/decode.js";
import { BootstrapVue } from "bootstrap-vue";
import Login from "@/components/Login";
import Home from "@/components/Home";
import CreateJob from "@/components/CreateJob";
import ManagerCreate from "@/components/ManagerCreate";
import ModelCreate from "@/components/ModelCreate";
import Job from "@/components/Job";

import "bootstrap/dist/css/bootstrap.css";
import "bootstrap-vue/dist/bootstrap-vue.css";
Vue.use(VueRouter);
Vue.use(BootstrapVue);

const routes = [
    {
        path: "/",
        name: "Home",
        component: Home,
    },
    {
        path: "/Login",
        name: "Login",
        component: Login,
    },
    {
        path: "/ModelCreate",
        name: "ModelCreate",
        component: ModelCreate,
    },
    {
        path: "/ManagerCreate",
        name: "ManagerCreate",
        component: ManagerCreate,
    },
    {
        path: "/Job",
        name: "CreateJob",
        component: CreateJob,
    },
    {
        path: "/Job/:id",
        name: "Job",
        component: Job,
    },
];

const router = new VueRouter({
    mode: "history",
    base: process.env.BASE_URL,
    routes,
});

router.beforeEach((to, from, next) => {
    var userRole = null;
    const jwt = localStorage.getItem("jwt");
    if (jwt !== null) {
        userRole = decode(jwt).role;
    }
    if (to.name !== 'Login' && (userRole !== 'Manager' && userRole !== 'Model')) next({ name: 'Login' });
    else if (to.name == 'ManagerCreate' && (userRole !== 'Manager')) next({ name: 'Home' });
    else if (to.name == 'ModelCreate' && (userRole !== 'Manager')) next({ name: 'Home' });
    else next();
})

export default router;
