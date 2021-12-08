<template>
    <div class="container">
        <job-manager v-if="userRole === 'Manager'"></job-manager>
        <job-model v-if="userRole === 'Model'"></job-model>
    </div>
</template>

<script>
import JobManager from "@/components/JobManager";
import JobModel from "@/components/ModelViews/JobModel";

import decode from "@/shared/decode.js";
export default {
    data() {
        return {
            userRole: null,
        };
    },
    components: {
        JobManager,
        JobModel,
    },
    created() {
        const jwt = localStorage.getItem("jwt");
        if (jwt !== null) {
            this.userRole = decode(jwt).role;
        }
    },
};
</script>
