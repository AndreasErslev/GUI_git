<template>
  <div class="AddModelToJob">
    <h1>Add model to job</h1>
  </div>
  <div class="container">
    <div class="row justify-content-center loginStyle">
      <div class="col-md-2">
        <label for="model">Model: </label>
      </div>
      <div class="col-md-4">
        <input
          type="text"
          v-model="model"
          name="Model"
          required
          class="inputStyle"
        />
      </div>
    </div>
    <div class="row justify-content-center loginStyle">
      <div class="col-md-2">
        <label for="job">Job: </label>
      </div>
      <div class="col-md-4">
        <input
          type="text"
          v-model="job"
          name="Job"
          required
          class="inputStyle"
        />
      </div>
    </div>

    <div class="row justify-content-center loginStyle">
      <div class="col-md-6">
        <input
          type="button"
          value="Add Job"
          v-on:click="summitModelToJob"
          class="buttonStyle"
        />
      </div>
    </div>
  </div>
</template>

<script>
var url = "https://localhost:44368/api/Jobs/{jobId}/model/{modelId}";
export default {
  data() {
    return {
      model: "",
      job: "",
    };
  },
  methods: {
    summitJob() {
      var bodyData = {
        model: this.model,
        job: this.job,
      };

      var promise = fetch(url, {
        body: JSON.stringify(bodyData),
        headers: new Headers({ "Content-type": "application/json" }),
        method: "POST",
      });

      promise
        .then((response) => response.json())
        .then((response) => {
          console.log("GOOD", response);
          alert("The job got added");
        })
        .catch((response) => {
          console.log("ERROR", response);
          alert("The job failed to be added");
        });

      this.model = "";
      this.job = "";
    },
  },
};
</script>

<style>
.loginStyle {
  margin-bottom: 2%;
}

.inputStyle {
  margin-left: 2%;
}

.buttonStyle {
  background-color: lightgreen;
  font-weight: bold;
  float: inherit;
  margin-left: 53% !important;
}
</style>
