<template>
  <table class="table-admin table-bordered" id="job-app">
    <thead>
      <tr>
        <th>Location</th>
        <th>Customer</th>
        <th>Start Date</th>
        <th>Days</th>
        <th>Comments</th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="(job, jobIndex) in jobs" :key="jobIndex">
        <td>
          {{ job.location }}
        </td>
        <td>
          {{ job.customer }}
        </td>
        <td>
          {{ job.startDate }}
        </td>
        <td>
          {{ job.days }}
        </td>
        <td>
          {{ job.comments }}
        </td>
      </tr>
    </tbody>
  </table>
</template>

<script>
var url = "https://localhost:44368/api/Jobs";
export default {
  data() {
    return {
      jobs: [],
    };
  },
  mounted() {
    var promise = fetch(url, {
      method: "GET",
      headers: {
        "content-type": "application/json",
        Authorization: "Bearer " + localStorage.getItem("token"),
      },
    });

    promise
      .then((response) => response.json())
      .then((response) => {
        console.log("GOOD", response);

        // inds�tte data i tabel:
        this.jobs = response;
      })
      .catch((response) => {
        console.log("ERROR", response);
      });
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
