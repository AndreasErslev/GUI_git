

<template>
    <div class="Login">
        <h1>Please login to your account</h1>
    </div>
    <div id="login">
        <div class="row">
            <div class="col-md-10 loginStyle">
                <label for="email">E-mail: </label>
                <input type="text" v-model="email" name="Email" required class="inputStyle" />
            </div>
            <div class="col-md-10 loginStyle">
                <label for="password">Password: </label>
                <input type="text" v-model="password" name="Password" required class="inputStyle" />
            </div>
            <div class="col-md-10 loginStyle">
                <login-button></login-button>
            </div>
        </div>
    </div>
</template>

<script>
    var url = document.location.origin + "/api/Account";
    app.component('login-button', {
        data: function () {
            return {
                email: "",
                password: ""
            };
        },
        template: '<input type="button" value="Login" v-on:click="summitLogin" class="buttonStyle"/>'
    })
    const LoginApp = createApp({
        methods: {
            summitLogin() {
                var bodyData = {
                    "email": this.email,
                    "password": this.password
                }

                var promise = fetch(url, {
                    body: JSON.stringify(bodyData),
                    headers: new Headers({ 'Content-type': 'application/json' }),
                    method: 'POST'
                });

                promise
                    .then(response => response.json())
                    .then(response => {
                        console.log("GOOD", response);
                        alert("The user got added");
                    })
                    .catch(response => {
                        console.log("ERROR", response);
                        alert("The user failed to be added");
                    });

                this.email = "";
                this.password = "";
            }
        }
    })
    LoginApp.mount("#login")
</script>

<style>
    .loginStyle {
        margin-bottom: 2%;
    }
    .inputStyle{
        margin-left: 2%;
    }
    .buttonStyle{
       background-color: lightgreen;
       font-weight: bold;
    }
</style>

