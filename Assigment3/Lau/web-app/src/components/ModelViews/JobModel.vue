<template>
    <div>
        <h3>Job info:</h3>
        <b-list-group>
            <b-list-group-item>Customer: {{ job.customer }}</b-list-group-item>
            <b-list-group-item
                >StartDate:
                {{
                    new Date(job.startDate).toLocaleDateString()
                }}</b-list-group-item
            >
            <b-list-group-item>Duration: {{ job.days }} days</b-list-group-item>
            <b-list-group-item>Location: {{ job.location }}</b-list-group-item>
            <b-list-group-item>Comments: {{ job.comments }}</b-list-group-item>
        </b-list-group>

        <h4>Models:</h4>
        <b-list-group>
            <b-list-group-item
                v-for="model in job.models"
                :key="model.efModelId"
                >First name: {{ model.firstName }} <br />
                Last name: {{ model.lastName }} <br />
                Email: {{ model.email }} <br />
                Phone: {{ model.phoneNo }}
            </b-list-group-item>
        </b-list-group>
        <b-button v-b-modal.modal-1>Add an expense</b-button>

        <b-modal ref="modal-1" id="modal-1" title="BootstrapVue" hide-footer >
            <p class="my-4">Please input information about your purchase:</p>
            <expense-create v-on:success="hideModal()" ></expense-create>
        </b-modal>
    </div>
</template>

<script>
import ExpenseCreate from "@/components/ModelViews/ExpenseCreate";
import { get } from "@/shared/fetch";

export default {
    data() {
        return {
            job: {
                customer: "",
                startDate: "",
                days: "",
                location: "",
                comments: "",
                models: "",
            },
        };
    },
    async created() {
        let result = await get("api/jobs/" + this.$route.params.id);
        this.job = await result.json();
    },
    components: {
        ExpenseCreate,
    },
    methods: {
        hideModal() {
        this.$refs['modal-1'].hide();
      },
    },
};
</script>
