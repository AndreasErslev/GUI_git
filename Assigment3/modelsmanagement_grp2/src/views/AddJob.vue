<template>
  <div class="AddJob">
    <h1>Add job</h1>
  </div>
  <div class="container">
    <div class="row justify-content-center loginStyle">
      <div class="col-md-2">
        <label for="customer">Customer: </label>
      </div>
      <div class="col-md-4">
        <input
          type="text"
          v-model="customer"
          name="Customer"
          required
          class="inputStyle"
        />
      </div>
    </div>
    <div class="row justify-content-center loginStyle">
      <div class="col-md-2">
        <label for="startDate">Start Date: </label>
      </div>
      <div class="col-md-4">
        <input
          type="text"
          v-model="startDate"
          name="StartDate"
          required
          class="inputStyle"
        />
      </div>
    </div>
    <div class="row justify-content-center loginStyle">
      <div class="col-md-2">
        <label for="days">Days: </label>
      </div>
      <div class="col-md-4">
        <input
          type="text"
          v-model="days"
          name="Days"
          required
          class="inputStyle"
        />
      </div>
    </div>
    <div class="row justify-content-center loginStyle">
      <div class="col-md-2">
        <label for="location">Location: </label>
      </div>
      <div class="col-md-4">
        <input
          type="text"
          v-model="location"
          name="Location"
          required
          class="inputStyle"
        />
      </div>
    </div>
    <div class="row justify-content-center loginStyle">
      <div class="col-md-2">
        <label for="comments">Comments: </label>
      </div>
      <div class="col-md-4">
        <textarea
          v-model="comments"
          name="Comments"
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
          v-on:click="summitJob"
          class="buttonStyle"
        />
      </div>
    </div>
  </div>
</template>

<script>
var url = "https://localhost:44368/api/Jobs";
export default {
  data() {
    return {
      customers: "",
      startDate: "",
      days: "",
      location: "",
      comments: "",
    };
  },
  methods: {
    summitJob() {
      var bodyData = {
        customers: this.customers,
        startDate: this.startDate,
        days: this.days,
        location: this.location,
        comments: this.comments,
      };

      var promise = fetch(url, {
        body: JSON.stringify(bodyData),
        headers: new Headers({ "Content-type": "application/json" }),
        method: "PUT",
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

      this.customers = "";
      this.startDate = "";
      this.days = "";
      this.location = "";
      this.comments = "";
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
