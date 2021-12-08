<template>

  <div>
  <h3>Your upcoming jobs:</h3>
    <div class="d-flex flex-column">
        <div class="card" v-for="job in jobs" :key="job.efJobId">
            <div class="card-body">
                <h4 class="card-title">{{ job.location }} {{new Date(job.startDate).toLocaleDateString()}} </h4>
                <div class="card-text">
                  <h5>Description:</h5>
                  <h6>{{job.comments}}</h6>
                  <h5>Duration: {{job.days}} days</h5>
                  <router-link :to="{name: 'Job', params: { id: job.efJobId }}" class="stretched-link"></router-link>
                </div>
            </div>
        </div>
    </div>
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
    created() {
        this.getModelJobs();
    },
    methods: {
        async getModelJobs() {
            let result = await get("api/jobs");
            if (result.status == 200) {
                this.jobs = await result.json();
            }
          },

            goToJobDetails(jobId) {
              router.push({ name: "Job", params: { id: jobId }});
            }
        },
        
    
}
</script>
