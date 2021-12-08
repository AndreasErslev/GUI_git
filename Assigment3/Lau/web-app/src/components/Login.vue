<template>
    <div
        class="d-flex flex-column w-100 h-100 align-items-center justify-content-center"
    >
        <h1 class="w-50">Login</h1>
        <form class="w-50" @submit.prevent="handleSubmit">
            <div class="form-group">
                <label for="email">
                    Email:
                </label>
                <input
                    type="text"
                    class="form-control"
                    name="email"
                    placeholder="Email address"
                    v-model="user.email"
                />
            </div>
            <div class="form-group">
                <label for="password">
                    Password:
                </label>
                <input
                    type="password"
                    class="form-control"
                    name="password"
                    placeholder="Password"
                    v-model="user.password"
                />
                <small class="text-danger" v-if="failed">Login failed</small>
            </div>
            <button class="btn btn-primary" type="submit">Log in</button>
        </form>
    </div>
</template>

<script>
import { post } from "@/shared/fetch.js";
import router from "@/router";

export default {
    data() {
        return {
            user: {
                email: "",
                password: "",
            },
            failed: false,
        };
    },

    methods: {
        async handleSubmit() {
            const response = await post("api/Account/Login", this.user);

            if (response.status === 200) {
                this.failed = false;
                const responseJson = await response.json();
                localStorage.setItem("jwt", responseJson.jwt);
                router.push({ name: "Home" });
            } else {
                this.handleFailedLogin();
            }
        },
        handleFailedLogin() {
            this.failed = true;
        },
    },
};
</script>
