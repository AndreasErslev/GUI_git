<template>
  <div class="CreateManager">
    <h1>Create a new manager account</h1>
  </div>
  <div class="container">
    <div class="row justify-content-center ManagerStyle">
      <div class="col-md-2">
        <label for="ManagerFName">First name: </label>
      </div>
      <div class="col-md-4">
        <input
          type="text"
          v-model="managerFName"
          name="ManagerFName"
          required
          class="inputStyle"
        />
      </div>
    </div>
    <div class="row justify-content-center ManagerStyle">
      <div class="col-md-2">
        <label for="ManagerLName">Last name: </label>
      </div>
      <div class="col-md-4">
        <input
          type="text"
          v-model="managerLName"
          name="ManagerLName"
          required
          class="inputStyle"
        />
      </div>
    </div>
    <div class="row justify-content-center ManagerStyle">
      <div class="col-md-2">
        <label for="ManagerAccount">Account: </label>
      </div>
      <div class="col-md-4">
        <input
          type="text"
          v-model="managerAccount"
          name="ManagerAccount"
          required
          class="inputStyle"
        />
      </div>
    </div>
    <div class="row justify-content-center ManagerStyle">
      <div class="col-md-2">
        <label for="email">E-mail: </label>
      </div>
      <div class="col-md-4">
        <input
          type="text"
          v-model="email"
          name="Email"
          required
          class="inputStyle"
        />
      </div>
    </div>
    <div class="row justify-content-center ManagerStyle">
      <div class="col-md-2">
        <label for="password">Password: </label>
      </div>
      <div class="col-md-4">
        <input
          type="text"
          v-model="password"
          name="Password"
          required
          class="inputStyle"
        />
      </div>
    </div>
    <div class="row justify-content-center ManagerStyle">
      <div class="col-md-2">
        <label for="isManager">Confirm management: </label>
      </div>
      <div class="col-md-4">
        <input
          type="checkbox"
          v-model="isManager"
          name="IsManager"
          required
          class="inputStyle"
        />
      </div>
    </div>
    <div class="row justify-content-center ManagerStyle">
      <div class="col-md-6">
        <input
          type="button"
          value="Create"
          v-on:click="createManager"
          class="buttonStyle"
        />
      </div>
    </div>
  </div>
</template>

<script>
var url = document.location.origin + "/api/Managers";
export default {
  data() {
    return {
      isManager: "",
      email: "",
      password: "",
      managerFName: "",
      managerLName: "",
      managerAccount: "",
    };
  },
  methods: {
    createManager() {
      var bodyData = {
        isManager: this.isManager,
        email: this.email,
        password: this.password,
        managerFName: this.managerFName,
        managerLName: this.managerLName,
        managerAccount: this.managerAccount,
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
          alert("The user got added");
        })
        .catch((response) => {
          console.log("ERROR", response);
          alert("The user failed to be added");
        });
      this.isManager = "";
      this.email = "";
      this.password = "";
      this.managerFName = "";
      this.managerLName = "";
      this.managerAccount = "";
    },
  },
};
</script>

<style>
.ManagerStyle {
  margin-bottom: 2%;
}

.inputStyle {
  margin-left: 2%;
}

.buttonStyle {
  background-color: lightgreen;
  font-weight: bold;
  float: inherit;
  margin-left: 59%;
}
</style>
