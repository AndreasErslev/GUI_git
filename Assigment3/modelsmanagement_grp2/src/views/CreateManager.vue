<template>
  <div>
    <img alt="Vue logo" src="../assets/logo.png" class="logo" />
  </div>
  <p class="standardText">Create a new manager account</p>
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
var url = "https://localhost:44368/api/Managers";
export default {
  data() {
    return {
      email: "",
      password: "",
      managerFName: "",
      managerLName: "",
    };
  },
  methods: {
    createManager() {
      var bodyData = {
        email: this.email,
        password: this.password,
        managerFName: this.managerFName,
        managerLName: this.managerLName,
      };

      var promise = fetch(url, {
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
          alert("The user got added");
        })
        .catch((response) => {
          console.log("ERROR", response);
          alert("The user failed to be added");
        });
      this.email = "";
      this.password = "";
      this.managerFName = "";
      this.managerLName = "";
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
