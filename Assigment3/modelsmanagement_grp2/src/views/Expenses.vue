<template>
  <div>
    <img alt="Vue logo" src="../assets/logo.png" class="logo" />
  </div>
  <p class="standardText">Add an expense to a chosen job</p>
  <div class="container">
    <div class="row justify-content-center ModelExpense">
      <div class="col-md-2">
        <label for="ExpenseText">Expense: </label>
      </div>
      <div class="col-md-4">
        <input
          type="text"
          v-model="expenseText"
          name="ExpenseText"
          required
          class="inputStyle"
        />
      </div>
    </div>
    <div class="row justify-content-center ModelExpense">
      <div class="col-md-2">
        <label for="Date">Date (YYYY-MM-DD): </label>
      </div>
      <div class="col-md-4">
        <input
          type="text"
          v-model="date"
          name="Date"
          required
          class="inputStyle"
        />
      </div>
    </div>
    <div class="row justify-content-center ModelExpense">
      <div class="col-md-2">
        <label for="Amount">Amount: </label>
      </div>
      <div class="col-md-4">
        <input
          type="text"
          v-model="amount"
          name="Amount"
          required
          class="inputStyle"
        />
      </div>
    </div>
    <div class="row justify-content-center ModelExpense">
      <div class="col-md-2">
        <label for="Job">Job: </label>
      </div>
      <div class="col-md-4">
        <select v-model="jobId">
          <option
            v-for="job in jobs"
            v-bind:key="job.efJobId"
            v-bind:value="job.efJobId"
          >
            {{ job.customer }}
          </option>
        </select>
      </div>
    </div>
  </div>

  <div class="row justify-content-center ModelExpense">
    <div class="col-md-6">
      <input
        type="button"
        value="Add Expense"
        v-on:click="addExpense"
        class="buttonStyle"
      />
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      expenseText: "",
      date: "",
      amount: "",
      expense: [],
      jobs: [],
      jobId: "",
    };
  },
  mounted() {
    var Joburl = "https://localhost:44368/api/jobs";
    var promise = fetch(Joburl, {
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
        console.log(JSON.stringify(response));
        this.jobs = response;
      })
      .catch((response) => {
        console.log("ERROR", response);
      });
  },
  methods: {
    addExpense() {
      var expenseUrl = "https://localhost:44368/api/Expenses";
      var bodyData = {
        expenseText: this.expenseText,
        date: this.date,
        amount: parseFloat(this.amount),
        modelId: parseInt(localStorage.getItem("modelId")),
        jobId: this.jobId,
      };

      var promise = fetch(expenseUrl, {
        body: JSON.stringify(bodyData),
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
          alert("The expense got added");
        })
        .catch((response) => {
          console.log("ERROR", response);
          alert("The expense failed to be added");
        });

      this.expenseText = "";
      this.date = "";
      this.amount = "";
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

.ModelExpense {
  margin-bottom: 2%;
}

.inputStyle {
  margin-left: 2%;
}

.buttonStyle {
  background-color: lightgreen;
  font-weight: bold;
  float: inherit;
  margin-left: 50%;
}
</style>
