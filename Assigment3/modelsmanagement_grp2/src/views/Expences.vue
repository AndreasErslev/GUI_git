<template>
  <div class="AddExpence">
    <h1>Add an expence to your job</h1>
  </div>
  <div class="container">
    <div class="row justify-content-center ModelExpence">
      <div class="col-md-2">
        <label for="ExpenceText">Expence: </label>
      </div>
      <div class="col-md-4">
        <input
          type="text"
          v-model="expenceText"
          name="ExpenceText"
          required
          class="inputStyle"
        />
      </div>
    </div>
    <div class="row justify-content-center ModelExpence">
      <div class="col-md-2">
        <label for="Date">Date (YYYY/MM/DD): </label>
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
    <div class="row justify-content-center ModelExpence">
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

    <div class="row justify-content-center ModelExpence">
      <div class="col-md-6">
        <input
          type="button"
          value="Add Expence"
          v-on:click="addExpence"
          class="buttonStyle"
        />
      </div>
    </div>
  </div>
</template>

<script>
var url = document.location.origin + "/api/Expences";
export default {
  data() {
    return {
      expenceText: "",
      date: "",
      amount: "",
    };
  },
  methods: {
    addExpence() {
      var bodyData = {
        expenceText: this.email,
        date: this.date,
        amount: this.amount,
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
          alert("The expence got added");
        })
        .catch((response) => {
          console.log("ERROR", response);
          alert("The expence failed to be added");
        });

      this.expenceText = "";
      this.date = "";
      this.amount = "";
    },
  },
};
</script>

<style>
.ModelExpence {
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
