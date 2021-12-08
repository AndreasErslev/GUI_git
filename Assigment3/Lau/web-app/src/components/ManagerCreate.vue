<template>
    <div class="d-flex flex-column w-100 h-100 align-items-center justify-content-center">
        <h1 class="w-50">Create New Manager</h1>
        <form class="w-50" @submit.prevent="handleSubmit">
            <div class="form-group">
                <label for="email">Email:</label>
                <input
                    type="text"
                    class="form-control"
                    name="email"
                    placeholder="Email address"
                    v-model="manager.email"
                />
            </div>
            <div class="form-group">
                <label for="firstname">First Name:</label>
                <input
                    type="text"
                    class="form-control"
                    name="firstname"
                    placeholder="First Name"
                    v-model="manager.firstname"
                />
            </div>
            <div class="form-group">
                <label for="lastname">Last Name:</label>
                <input
                    type="text"
                    class="form-control"
                    name="lastname"
                    placeholder="First Name"
                    v-model="manager.lastname"
                />
            </div>
            <div class="form-group">
                <label for="password">Password:</label>
                <input
                    type="password"
                    class="form-control"
                    name="password"
                    placeholder="Password"
                    v-model="manager.password"
                />
                <small class="text-danger" v-if="failed">Creation failed</small>
            </div>
            <button class="btn btn-primary" type="submit">Create New Manager</button>
        </form>
    </div>
</template>

<script>
import { post } from "@/shared/fetch";
import router from "@/router";

export default {
    data() {
        return {
            manager: {
                firstname: "",
                lastname: "",
                email: "",
                password: "",
            },
            failed: false,
        };
    },
    methods: {
        async handleSubmit() {
            let response = await post("api/Managers", this.manager);
            console.log(response);
            if (response.status === 201) {
                this.failed = false;
                router.push({ name: "Home" });
            } else {
                this.failed = true;
            }
        },
    },
};
</script>