<template>
    <div class="CreateManager">
        <h1>Create a new model account</h1>
    </div>
    <div class="container">
        <div class="row justify-content-center CMStyle">
            <!-- Account-->
            <div class="col-md-2">
                <label for="Account">Account: </label>
            </div>
            <div class="col-md-4">
                <input type="text"
                       v-model="Account"
                       name="account"
                       required
                       class="inputStyle" />
            </div>
        </div>
        <br />
        <div class="row justify-content-center CMStyle">
            <!-- First Name-->
            <div class="col-md-2">
                <label for="FirstName">First Name: </label>
            </div>
            <div class="col-md-4">
                <input type="text"
                       v-model="FirstName"
                       name="first name"
                       required
                       class="inputStyle" />
            </div>
        </div>
        <br />
        <div class="row justify-content-center CMStyle">
            <!-- Last Name-->
            <div class="col-md-2">
                <label for="LastName">Last Name: </label>
            </div>
            <div class="col-md-4">
                <input type="text"
                       v-model="LastName"
                       name="last name"
                       required
                       class="inputStyle" />
            </div>
        </div>
        <br />
        <div class="row justify-content-center CMStyle">
            <!-- Email-->
            <div class="col-md-2">
                <label for="Email">E-mail: </label>
            </div>
            <div class="col-md-4">
                <input type="text"
                       v-model="Email"
                       name="email"
                       required
                       class="inputStyle" />
            </div>
        </div>
        <br />
        <div class="row justify-content-center CMStyle">
            <!-- Phone Number -->
            <div class="col-md-2">
                <label for="PhoneNo">Phone Number: </label>
            </div>
            <div class="col-md-4">
                <input type="text"
                       v-model="PhoneNo"
                       name="phoneNo"
                       required
                       class="inputStyle" />
            </div>
        </div>
        <br />
        <div class="row justify-content-center CMStyle">
            <!-- AddresLine1-->
            <div class="col-md-2">
                <label for="AddresLine1">Addres One: </label>
            </div>
            <div class="col-md-4">
                <input type="text"
                       v-model="AddresLine1"
                       name="addres1"
                       required
                       class="inputStyle" />
            </div>
        </div>
        <br />
        <div class="row justify-content-center CMStyle">
            <!-- AddresLine2-->
            <div class="col-md-2">
                <label for="AddresLine2">Addres Two: </label>
            </div>
            <div class="col-md-4">
                <input type="text"
                       v-model="AddresLine2"
                       name="addres2"
                       class="inputStyle" />
            </div>
        </div>
        <br />
        <div class="row justify-content-center CMStyle">
            <!-- Zip-->
            <div class="col-md-2">
                <label for="Zip">Zip-Code: </label>
            </div>
            <div class="col-md-4">
                <input type="text"
                       v-model="Zip"
                       name="zip"
                       required
                       class="inputStyle" />
            </div>
        </div>
        <br />
        <div class="row justify-content-center CMStyle">
            <!-- Zip-->
            <div class="col-md-2">
                <label for="City">City: </label>
            </div>
            <div class="col-md-4">
                <input type="text"
                       v-model="City"
                       name="city"
                       required
                       class="inputStyle" />
            </div>
        </div>
        <br />
        <div class="row justify-content-center CMStyle">
            <!-- City-->
            <div class="col-md-2">
                <label for="Country">Country: </label>
            </div>
            <div class="col-md-4">
                <input type="text"
                       v-model="Country"
                       name="country"
                       required
                       class="inputStyle" />
            </div>
        </div>
        <br />
        <div class="row justify-content-center CMStyle">
            <!-- BirthDate-->
            <div class="col-md-2">
                <label for="BirthDate">Birth Date: </label>
            </div>
            <div class="col-md-4">
                <input type="text"
                       v-model="BirthDate"
                       name="birthDate"
                       required
                       class="inputStyle" />
            </div>
        </div>
        <br />
        <div class="row justify-content-center CMStyle">
            <!-- Nationality-->
            <div class="col-md-2">
                <label for="Nationality">Nationality: </label>
            </div>
            <div class="col-md-4">
                <input type="text"
                       v-model="Nationality"
                       name="nationality"
                       required
                       class="inputStyle" />
            </div>
        </div>
        <br />
        <div class="row justify-content-center CMStyle">
            <!-- Height-->
            <div class="col-md-2">
                <label for="Height">Height: </label>
            </div>
            <div class="col-md-4">
                <input type="text"
                       v-model="Height"
                       name="height"
                       required
                       class="inputStyle" />
            </div>
        </div>
        <br />
        <div class="row justify-content-center CMStyle">
            <!-- ShoeSize-->
            <div class="col-md-2">
                <label for="ShoeSize">Shoe Size: </label>
            </div>
            <div class="col-md-4">
                <input type="text"
                       v-model="ShoeSize"
                       name="shoeSize"
                       required
                       class="inputStyle" />
            </div>
        </div>
        <br />
        <div class="row justify-content-center CMStyle">
            <!-- HairColor-->
            <div class="col-md-2">
                <label for="HairColor">Hair Color: </label>
            </div>
            <div class="col-md-4">
                <input type="text"
                       v-model="HairColor"
                       name="hairColor"
                       required
                       class="inputStyle" />
            </div>
        </div>
        <br />
        <div class="row justify-content-center CMStyle">
            <!-- EyeColor-->
            <div class="col-md-2">
                <label for="HairColor">Eye Color: </label>
            </div>
            <div class="col-md-4">
                <input type="text"
                       v-model="EyeColor"
                       name="EyeColor"
                       required
                       class="inputStyle" />
            </div>
        </div>
        <br />
        <div class="row justify-content-center CMStyle">
            <!-- Comments-->
            <div class="col-md-2">
                <label for="Comments">Comments: </label>
            </div>
            <div class="col-md-4">
                <input type="text"
                       v-model="Comments"
                       name="comments"
                       class="inputStyle" />
            </div>
        </div>
        <br />
        <div class="row justify-content-center CMStyle">
            <div class="col-md-6">
                <input type="button"
                       value="Login"
                       v-on:click="summitModel"
                       class="buttonStyle" />
            </div>
        </div>
        <br />
    </div>
</template>

<script>
var url = document.location.origin + "/api/Account";
export default {
  data() {
    return {
        Account: "",
        FirstName: "",
        LastName: "",
        Email: "",
        PhoneNo: "",
        AddresLine1: "",
        AddresLine2: "",
        Zip: "",
        City: "",
        Country: "",
        BirthDate: "",
        Nationality: "",
        Height: "",
        ShoeSize: "",
        HairColor: "",
        EyeColor: "",
        Comments: "",

    };
  },
  methods: {
    summitModel() {
          var bodyData = {
              Account: this.Account,
              FirstName: this.FirstName,
              LastName: this.LastName,
              Email: this.Email,
              PhoneNo: this.PhoneNo,
              AddresLine1: this.AddresLine1,
              AddresLine2: this.AddresLine2,
              Zip: this.Zip,
              City: this.City,
              Country: this.Country,
              BirthDate: this.BirthDate,
              Nationality: this.Nationality,
              Height: this.Height,
              ShoeSize: this.ShoeSize,
              HairColor: this.HairColor,
              EyeColor: this.EyeColor,
              Comments: this.Comments,
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

          this.Account = "";
          this.FirstName = "";
          this.LastName = "";
          this.Email = "";
          this.PhoneNo = "";
          this.AddresLine1 = "";
          this.AddresLine2 = "";
          this.Zip = "";
          this.City = "";
          this.Country = "";
          this.BirthDate = "";
          this.Nationality = "";
          this.Height = "";
          this.ShoeSize = "";
          this.HairColor = "";
          this.EyeColor = "";
          this.Comments = "";
    },
  },
};
</script>

<style>
    CMStyle {
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
