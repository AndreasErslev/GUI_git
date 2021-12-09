<template>
  <div>
    <img alt="Vue logo" src="../assets/logo.png" class="logo" />
  </div>
  <p class="standardText">List of Jobs</p>
  <p class="text-under">As a manager you can remove or add models to a job</p>
  <table class="job-manager-frist-tabel">
    <thead>
      <tr>
        <th>Customer</th>
        <th>Start Date</th>
        <th>Days</th>
        <th>Location</th>
        <th>Comments</th>
        <th>Remove Models</th>
        <th>Add Models</th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="(job, jobIndex) in jobs" :key="jobIndex">
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
          {{ job.location }}
        </td>
        <td>
          {{ job.comments }}
        </td>
        <td>
          <table>
            <tr>
              <td v-for="(model, modelIndex) in job.models" :key="modelIndex">
                <a href="#" v-on:click="deleteModel(model.email, job.jobId)"
                  >Remove {{ model.firstName }}
                </a>
              </td>
            </tr>
          </table>
        </td>

        <td>
          <table>
            <tr>
              <td v-for="(model, modelIndex) in models" :key="modelIndex">
                <a
                  href="#"
                  v-on:click="addModelToJob(model.efModelId, job.jobId)"
                  >Add {{ model.firstName }}
                </a>
              </td>
            </tr>
          </table>
        </td>
      </tr>
    </tbody>
  </table>
</template>

<script>
export default {
  data() {
    return {
      jobs: [],
      models: [],
    };
  },

  mounted() {
    var getJobsUrl = "https://localhost:44368/api/Jobs";
    fetch(getJobsUrl, {
      method: "GET",
      headers: {
        "content-type": "application/json",
        Authorization: "Bearer " + localStorage.getItem("token"),
      },
    })
      .then((response) => response.json())
      .then((response) => {
        console.log("GOOD", response);
        var allJobs = response;
        allJobs.forEach((job) => {
          var promise = fetch(getJobsUrl + "/" + job.efJobId, {
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
              // add hvert job med models til jobs[]
              this.jobs.push(response);
            })
            .catch((response) => {
              console.log("ERROR", response);
            });
        });
      })
      .catch((response) => {
        console.log("ERROR", response);
      });

    var getModelsUrl = "https://localhost:44368/api/Models";
    fetch(getModelsUrl, {
      method: "GET",
      headers: {
        "content-type": "application/json",
        Authorization: "Bearer " + localStorage.getItem("token"),
      },
    })
      .then((response) => response.json())
      .then((response) => {
        console.log("GOOD", response);
        this.models = response;
      })
      .catch((response) => {
        console.log("ERROR", response);
      });
  },
  methods: {
    deleteModel(email, jobId) {
      var foundModel = this.models.find((model) => model.email == email);
      var modelId = foundModel.efModelId;
      console.log("FOUND", jobId);
      var deleteJobUrl = "https://localhost:44368/api/Jobs";
      var promise = fetch(deleteJobUrl + "/" + jobId + "/model/" + modelId, {
        method: "DELETE",
        headers: {
          "content-type": "application/json",
          Authorization: "Bearer " + localStorage.getItem("token"),
        },
      });

      promise
        .then((response) => {
          console.log("GOOD", response);

          alert("model with id: " + foundModel.firstName + " has been deleted");
          this.$router.push("/JobsManager");
        })
        .catch((response) => {
          console.log("ERROR", response);
        });
    },
    addModelToJob(modelId, jobId) {
      var addJobUrl = "https://localhost:44368/api/Jobs";
      var promise = fetch(addJobUrl + "/" + jobId + "/model/" + modelId, {
        method: "POST",
        headers: {
          "content-type": "application/json",
          Authorization: "Bearer " + localStorage.getItem("token"),
        },
      });

      promise
        .then((response) => response.json())
        .then((response) => {
          console.log("GOOD", response);

          alert("model with id: " + modelId + " has been added to job");
          this.$router.push("/JobsManager");
        })
        .catch((response) => {
          console.log("ERROR", response);
        });
    },
  },
};
</script>

<style>
.logo {
  width: 40%;
}

.standardText {
  font-size: 22px;
  font-style: italic;
  font-weight: bold;
}

.text-under {
  font-size: 20px;
  font-style: italic;
}

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

.job-manager-frist-tabel {
  margin: 20px auto;
}
</style>
