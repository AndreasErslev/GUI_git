<template>
    <div class="col-12" v-if="job !== null">
        <h1>{{ job.location }}</h1>
        <br />
        <h4>Total expenses for job</h4>
        <table class="table table-light table-bordered">
            <tbody>
                <tr>
                    <td scope="row">Expense</td>
                    <td style="text-align: right">{{ expenses }}</td>
                </tr>
            </tbody>
        </table>

        <hr />

        <table class="table table-striped table-light table-bordered">
            <thead class="thead-dark">
                <tr>
                    <td scope="col">Name</td>
                    <td scope="col">Email</td>
                    <td scope="col">Phone number</td>
                    <td scope="col"></td>
                </tr>
            </thead>
            <tbody>
                <tr v-for="model in job.models" :key="model.efModelId">
                    <td scope="row">
                        {{ model.firstName }} {{ model.lastName }}
                    </td>
                    <td>{{ model.email }}</td>
                    <td>{{ model.phoneNo }}</td>
                    <td style="text-align: right">
                        <button
                            class="btn btn-danger"
                            v-on:click="removeModel(model.efModelId)"
                        >
                            Remove
                        </button>
                    </td>
                </tr>
            </tbody>
        </table>

        <hr />
        <h1>Available models</h1>

        <table class="table table-striped table-light table-bordered">
            <thead class="thead-dark">
                <tr>
                    <td scope="col">Name</td>
                    <td scope="col">Email</td>
                    <td scope="col">Phone number</td>
                    <td scope="col"></td>
                </tr>
            </thead>
            <tbody>
                <tr v-for="model in diffModels()" :key="model.efModelId">
                    <td scope="row">
                        {{ model.firstName }} {{ model.lastName }}
                    </td>
                    <td>{{ model.email }}</td>
                    <td>{{ model.phoneNo }}</td>
                    <td style="text-align: right">
                        <button
                            class="btn btn-primary"
                            v-on:click="addModel(model.efModelId)"
                        >
                            Add
                        </button>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script>
import { get, del, post } from "@/shared/fetch.js";
export default {
    data() {
        return {
            job: null,
            models: [],
            expenses: 0,
        };
    },
    methods: {
        async getJob() {
            const response = await get("api/jobs/" + this.$route.params.id);
            this.job = await response.json();
        },
        async getModels() {
            const response = await get("api/models");
            this.models = await response.json();
        },
        async getExpenses() {
            const response = await get("api/expenses");
            const expensesArray = await response.json();
            this.expenses = expensesArray
                .filter(e => e.jobId == this.$route.params.id)
                .reduce((sum, current) => sum + current.amount, 0);
        },
        diffModels() {
            return this.models.filter(
                model =>
                    !this.job.models
                        .map(m => m.efModelId)
                        .includes(model.efModelId)
            );
        },
        putIdsOnModelsInJob() {
            this.job.models = this.job.models.map(model => {
                model.efModelId = this.models.find(
                    m => m.email == model.email
                ).efModelId;
                return model;
            });
        },
        async removeModel(modelId) {
            const jobId = this.$route.params.id;
            await del("api/jobs/" + jobId + "/model/" + modelId);

            await this.getJob();
            this.putIdsOnModelsInJob();
        },
        async addModel(modelId) {
            const jobId = this.$route.params.id;
            await post("api/jobs/" + jobId + "/model/" + modelId);

            await this.getJob();
            this.putIdsOnModelsInJob();
        },
    },
    async created() {
        const jobPromise = this.getJob();
        const modelPromise = this.getModels();
        this.getExpenses();
        await Promise.all([jobPromise, modelPromise]);
        this.putIdsOnModelsInJob();
    },
};
</script>
