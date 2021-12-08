<template>
    <div class="d-flex flex-column w-100 h-100 align-items-center justify-content-center">
        <h1 class="w-50">Create New Job</h1>
        <form class="w-50" @submit.prevent="handleSubmit">
            <div class="form-group">
                <label for="customer">Customer:</label>
                <input
                    type="text"
                    class="form-control"
                    name="customer"
                    placeholder="Customer"
                    v-model="job.customer"
                />
            </div>
            <div class="form-group">
                <label for="startDate">Start Date:</label>
                <input type="date" class="form-control" name="startDate" v-model="job.startDate" />
            </div>
            <div class="form-group">
                <label for="days">Days:</label>
                <input
                    type="number"
                    class="form-control"
                    name="days"
                    v-model="job.days"
                />
            </div>
            <div class="form-group">
                <label for="location">Location:</label>
                <input
                    type="text"
                    class="form-control"
                    name="location"
                    placeholder="Location"
                    v-model="job.location"
                />
            </div>
            <div class="form-group">
                <label for="comments">Comments:</label>
                <input
                    type="text"
                    class="form-control"
                    name="comments"
                    placeholder="Comments"
                    v-model="job.comments"
                />
                <small class="text-danger" v-if="failed">Creation failed</small>
            </div>
            <button class="btn btn-primary" type="submit">Create New Job</button>
        </form>
    </div>
</template>

<script>
import { post } from "@/shared/fetch";
import router from "@/router";

export default {
    data() {
        return {
            job: {
                customer: "",
                startDate: "",
                days: 0,
                location: "",
                comments: "",
            },
            failed: false,
        };
    },
    methods: {
        async handleSubmit() {
            this.job.days = parseInt(this.job.days);
            let response = await post("api/Jobs", this.job);
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