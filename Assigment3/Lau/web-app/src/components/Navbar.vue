<template>
    <nav class="navbar navbar-expand-lg navbar-dark bg-custom fixed-top">
        <div class="container-fluid">
            <ul class="nav navbar-nav">
                <router-link class="navbar-brand" to="/"
                    >ModelTron2000</router-link
                >
                <router-link class="nav-link" to="/">Home</router-link>
                <router-link
                    class="nav-link"
                    v-if="role === 'Manager'"
                    to="/ModelCreate"
                    >Model(Create)</router-link
                >
                <router-link
                    class="nav-link"
                    v-if="role === 'Manager'"
                    to="/ManagerCreate"
                    >Manager(Create)</router-link
                >
            </ul>
            <ul class="nav navbar-nav">
                <router-link class="nav-link" to="Login" v-if="!isLoggedIn"
                    >Login</router-link
                >
                <a
                    href="javascript:void(0);"
                    class="nav-link"
                    v-if="isLoggedIn"
                    v-on:click="logout"
                    >Log out</a
                >
            </ul>
        </div>
    </nav>
</template>
<script>
import router from "@/router";
import decode from "@/shared/decode.js";
export default {
    data() {
        return {
            isLoggedIn: false,
            role: null,
        };
    },
    methods: {
        checkLoggedIn() {
            const jwt = localStorage.getItem("jwt");
            this.isLoggedIn = !!jwt;
            this.role = jwt ? decode(jwt).role : null;
        },
        logout() {
            localStorage.removeItem("jwt");
            this.checkLoggedIn();
            router.push({ name: "Login" });
        },
    },
    created() {
        this.checkLoggedIn();
    },
    watch: {
        $route() {
            this.checkLoggedIn();
        },
    },
};
</script>

<style>
.bg-custom {
    background-color: #34495e !important;
}
</style>
