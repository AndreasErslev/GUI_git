<template>
  <div class="Login">
    <h1>Please login to your account</h1>
  </div>
  <div class="container">
      <div class="row justify-content-center loginStyle">
          <div class="col-md-2">
              <label for="email">E-mail: </label>
          </div>
          <div class="col-md-4">
              <input type="text"
                     v-model="email"
                     name="Email"
                     required
                     class="inputStyle" />
          </div>
      </div>
      <div class="row justify-content-center loginStyle">
          <div class="col-md-2">
              <label for="password">Password: </label>
          </div>
          <div class="col-md-4">
              <input type="text"
                     v-model="password"
                     name="Password"
                     required
                     class="inputStyle" />
          </div>
      </div>
      <div class="row justify-content-center loginStyle">
          <div class="col-md-6">
              <input type="button"
                     value="Login"
                     v-on:click="summitLogin"
                     class="buttonStyle" />
          </div>
      </div>
  </div>
</template>

<script>
var url = document.location.origin + "/api/Account";
export default {
  data() {
    return {
      email: "",
      password: "",
    };
  },
  methods: {
    summitLogin() {
      var bodyData = {
        email: this.email,
        password: this.password,
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

      this.email = "";
      this.password = "";
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
  float: right;
}
</style>
