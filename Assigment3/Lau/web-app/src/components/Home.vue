<template>
    <div class="container">
        <home-manager v-if="userRole === 'Manager'"></home-manager>
        <home-model v-if="userRole === 'Model'"></home-model>

        <div class="col-4" v-if="userRole === null">
            <h1>Home</h1>
            <p>Please login</p>
        </div>
    </div>
</template>

<script>
import HomeManager from "@/components/HomeManager";
import decode from "@/shared/decode.js";
import HomeModel from "@/components/ModelViews/HomeModel";
export default {
    data() {
        return {
            userRole: null,
        };
    },
    components: {
        HomeManager,
        HomeModel,
    },
    created() {
        const jwt = localStorage.getItem("jwt");
        if (jwt !== null) {
            this.userRole = decode(jwt).role;
        } else {
            this.userRole = null;
        }
    },
};
</script>
