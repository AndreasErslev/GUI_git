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
        <input
          type="text"
          v-model="email"
          name="Email"
          required
          class="inputStyle"
        />
      </div>
    </div>
    <div class="row justify-content-center loginStyle">
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
    <div class="row justify-content-center loginStyle">
      <div class="col-md-6">
        <input
          type="button"
          value="Login"
          v-on:click="submitLogin"
          class="buttonStyle"
        />
      </div>
    </div>
  </div>
</template>

<script>
var url = "https://localhost:44368/api/Account/login";
export default {
  data() {
    return {
      email: "",
      password: "",
    };
  },
  methods: {
    async submitLogin() {
      var bodyData = {
        email: this.email,
        password: this.password,
      };
      try {
        let response = await fetch(url, {
          method: "POST",
          body: JSON.stringify(bodyData), // Assumes data is in an object called form
          headers: new Headers({
            "Content-Type": "application/json",
          }),
        });
        if (response.ok) {
          let token = await response.json();
          localStorage.setItem("token", token.jwt);
          // console.log("Got token: " + token.jwt);
          let payload = this.parseJwt(token.jwt);

          Object.keys(payload).forEach((key) => {
            if (key.indexOf("role") !== -1) {
              payload["role"] = payload[key];
            }

            if (key.indexOf("emailaddress") !== -1) {
              payload["email"] = payload[key];
            }
          });
          localStorage.setItem("email", payload.email);
          localStorage.setItem("role", payload.role);
          localStorage.setItem("modelId", payload.ModelId);
          // Gå til home siden efter login:
          this.$router.push("/");
        } else {
          alert("Server returned: " + response.statusText);
        }
      } catch (err) {
        alert("Error: " + err);
      }
      this.email = "";
      this.password = "";
    },

    parseJwt(token) {
      var base64Url = token.split(".")[1];
      var base64 = base64Url.replace(/-/g, "+").replace(/_/g, "/");
      var jsonPayload = decodeURIComponent(
        atob(base64)
          .split("")
          .map(function (c) {
            return "%" + ("00" + c.charCodeAt(0).toString(16)).slice(-2);
          })
          .join("")
      );

      return JSON.parse(jsonPayload);
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
  margin-left: 59%;
}
</style>
