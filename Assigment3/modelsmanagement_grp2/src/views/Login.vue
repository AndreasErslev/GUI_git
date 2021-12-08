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
    async login() {
        let url = "https://localhost:44368/api/account/login";
        try {
            let response = await fetch(url, {
                method: "POST",
                body: JSON.stringify(this.form), // Assumes data is in an object called form
                headers: new Headers({
                    "Content-Type": "application/json"
                })
            });
            if (response.ok) {
                let token = await response.json();
                localStorage.setItem("token", token.jwt);
                // Change view to some other component
                let payload = parseJwt(token);
                localStorage.setItem("email", payload.schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress);
                //Set id og rolle
                
            } else {
                alert("Server returned: " + response.statusText);
            }
        } catch (err) {
            alert("Error: " + err);
        }
        return;
        },
        function parseJwt(token) {
        var base64Url = token.split('.')[1];
        var base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
        var jsonPayload = decodeURIComponent(atob(base64).split('').map(function (c) {
            return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
        }).join(''));

        return JSON.parse(jsonPayload);
    };
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
  margin-left: 59%;
}
</style>
