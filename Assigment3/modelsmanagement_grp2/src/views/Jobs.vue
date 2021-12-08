
<template>
    <div class="container">
        <jobs-manager v-if="userRole === 'Manager'" />
        <jobs-model v-if="userRole === 'Model'" />
    </div>
</template>

<script>
    import JobsManager from "@/views/JobsManager";
    import JobsModel from "@/views/JobsModel";

    export default {
        data() {
            return {
                userRole: null,
            };
        },
        components: {
            JobsManager,
            JobsModel,
        },
        createJob() {
            const JWT = localStorage.getItem("jwt");
            if (jwt != null) {
                this.userRole = parseJwt(token).role;
            }
        }
    }
</script>