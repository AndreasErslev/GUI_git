<template>
    <div class="col-12">
        <h1>Jobs:</h1>
        <h5 style="color: red">
            <b>Click on a job to view more specifics</b>
        </h5>
        <table
            class="table table-striped table-hover table-light table-bordered"
        >
            <thead class="thead-dark">
                <tr>
                    <td scope="col">
                        Customer
                    </td>
                    <td scope="col">
                        Location
                    </td>
                    <td scope="col">
                        Date
                    </td>
                    <td scope="col">
                        Days
                    </td>
                </tr>
            </thead>
            <tbody>
                <tr
                    v-for="job in jobs"
                    :key="job.efJobId"
                    v-on:click="goToJob(job.efJobId)"
                    class="hoverable"
                >
                    <td scope="row">{{ job.customer }}</td>
                    <td>{{ job.location }}</td>
                    <td>{{ new Date(job.startDate).toLocaleString() }}</td>
                    <td>{{ job.days }}</td>
                </tr>
            </tbody>
        </table>
        <button class="btn btn-primary" v-on:click="createNewJob()">
            Create new job
        </button>
    </div>
</template>

<script>
import { get } from "@/shared/fetch";
import router from "@/router";

export default {
    data() {
        return {
            jobs: [],
        };
    },
    methods: {
        createNewJob() {
            router.push({ name: "CreateJob" });
        },
        goToJob(jobid) {
            router.push({ name: "Job", params: { id: jobid } });
        },
    },
    async created() {
        let jobs = await get("api/jobs");
        if (jobs.status === 200) {
            this.jobs = await jobs.json();
        }
    },
};
</script>

<style scoped>
.hoverable:hover {
    cursor: pointer;
}
</style>
