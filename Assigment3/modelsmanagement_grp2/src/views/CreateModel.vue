import router from './main.js';

<template>
  <div>
    <img alt="Vue logo" src="../assets/logo.png" class="logo" />
  </div>
  <p class="standardText">Create a new model account</p>
  <div class="container">
    <div class="row justify-content-center CMStyle">
      <!-- First Name-->
      <div class="col-md-2">
        <label for="FirstName">First Name: </label>
      </div>
      <div class="col-md-4">
        <input
          type="text"
          v-model="FirstName"
          name="FirstName"
          required
          class="inputStyle"
        />
      </div>
    </div>

    <div class="row justify-content-center CMStyle">
      <!-- Last Name-->
      <div class="col-md-2">
        <label for="LastName">Last Name: </label>
      </div>
      <div class="col-md-4">
        <input
          type="text"
          v-model="LastName"
          name="LastName"
          required
          class="inputStyle"
        />
      </div>
    </div>

    <div class="row justify-content-center CMStyle">
      <!-- Email -->
      <div class="col-md-2">
        <label for="Email">E-mail: </label>
      </div>
      <div class="col-md-4">
        <input
          type="text"
          v-model="Email"
          name="Email"
          required
          class="inputStyle"
        />
      </div>
    </div>

    <div class="row justify-content-center CMStyle">
      <!-- Password -->
      <div class="col-md-2">
        <label for="Password">Password: </label>
      </div>
      <div class="col-md-4">
        <input
          type="text"
          v-model="Password"
          name="Password"
          required
          class="inputStyle"
        />
      </div>
    </div>

    <div class="row justify-content-center CMStyle">
      <!-- Phone Number -->
      <div class="col-md-2">
        <label for="PhoneNo">Phone Number: </label>
      </div>
      <div class="col-md-4">
        <input
          type="text"
          v-model="PhoneNo"
          name="PhoneNo"
          required
          class="inputStyle"
        />
      </div>
    </div>

    <div class="row justify-content-center CMStyle">
      <!-- AddresLine1-->
      <div class="col-md-2">
        <label for="AddresLine1">Addres One: </label>
      </div>
      <div class="col-md-4">
        <input
          type="text"
          v-model="AddresLine1"
          name="AdressLines1"
          required
          class="inputStyle"
        />
      </div>
    </div>

    <div class="row justify-content-center CMStyle">
      <!-- AddresLine2-->
      <div class="col-md-2">
        <label for="AddresLine2">Addres Two: </label>
      </div>
      <div class="col-md-4">
        <input
          type="text"
          v-model="AddresLine2"
          name="AddresLine2"
          class="inputStyle"
        />
      </div>
    </div>

    <div class="row justify-content-center CMStyle">
      <!-- Zip-->
      <div class="col-md-2">
        <label for="Zip">Zip-Code: </label>
      </div>
      <div class="col-md-4">
        <input
          type="text"
          v-model="Zip"
          name="Zip"
          required
          class="inputStyle"
        />
      </div>
    </div>

    <div class="row justify-content-center CMStyle">
      <!-- Zip-->
      <div class="col-md-2">
        <label for="City">City: </label>
      </div>
      <div class="col-md-4">
        <input
          type="text"
          v-model="City"
          name="City"
          required
          class="inputStyle"
        />
      </div>
    </div>

    <div class="row justify-content-center CMStyle">
      <!-- City-->
      <div class="col-md-2">
        <label for="Country">Country: </label>
      </div>
      <div class="col-md-4">
        <input
          type="text"
          v-model="Country"
          name="Country"
          required
          class="inputStyle"
        />
      </div>
    </div>

    <div class="row justify-content-center CMStyle">
      <!-- BirthDate-->
      <div class="col-md-2">
        <label for="BirthDate">Birth Date (YYYY-MM-DD): </label>
      </div>
      <div class="col-md-4">
        <input
          type="text"
          v-model="BirthDate"
          name="BirthDate"
          required
          class="inputStyle"
        />
      </div>
    </div>

    <div class="row justify-content-center CMStyle">
      <!-- Nationality-->
      <div class="col-md-2">
        <label for="Nationality">Nationality: </label>
      </div>
      <div class="col-md-4">
        <input
          type="text"
          v-model="Nationality"
          name="Nationality"
          required
          class="inputStyle"
        />
      </div>
    </div>

    <div class="row justify-content-center CMStyle">
      <!-- Height-->
      <div class="col-md-2">
        <label for="Height">Height (CM): </label>
      </div>
      <div class="col-md-4">
        <input
          type="text"
          v-model="Height"
          name="Height"
          required
          class="inputStyle"
        />
      </div>
    </div>

    <div class="row justify-content-center CMStyle">
      <!-- ShoeSize-->
      <div class="col-md-2">
        <label for="ShoeSize">Shoe Size: </label>
      </div>
      <div class="col-md-4">
        <input
          type="text"
          v-model="ShoeSize"
          name="ShoeSize"
          required
          class="inputStyle"
        />
      </div>
    </div>

    <div class="row justify-content-center CMStyle">
      <!-- HairColor-->
      <div class="col-md-2">
        <label for="HairColor">Hair Color: </label>
      </div>
      <div class="col-md-4">
        <input
          type="text"
          v-model="HairColor"
          name="HairColor"
          required
          class="inputStyle"
        />
      </div>
    </div>

    <div class="row justify-content-center CMStyle">
      <!-- EyeColor-->
      <div class="col-md-2">
        <label for="EyeColor">Eye Color: </label>
      </div>
      <div class="col-md-4">
        <input
          type="text"
          v-model="EyeColor"
          name="EyeColor"
          required
          class="inputStyle"
        />
      </div>
    </div>

    <div class="row justify-content-center CMStyle">
      <!-- Comments-->
      <div class="col-md-2">
        <label for="Comments">Comments: </label>
      </div>
      <div class="col-md-4">
        <input
          type="text"
          v-model="Comments"
          name="Comments"
          class="inputStyle"
        />
      </div>
    </div>

    <div class="row justify-content-center CMStyle">
      <div class="col-md-6">
        <input
          type="button"
          value="Create model"
          v-on:click="submitModel"
          class="buttonStyle"
        />
      </div>
    </div>
  </div>
</template>

<script>
var url = "https://localhost:44368/api/Models";
export default {
  data() {
    return {
      Account: "",
      FirstName: "",
      LastName: "",
      Email: "",
      Password: "",
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
    submitModel() {
      var bodyData = {
        Account: this.Account,
        FirstName: this.FirstName,
        LastName: this.LastName,
        Email: this.Email,
        Password: this.Password,
        PhoneNo: this.PhoneNo,
        AddresLine1: this.AddresLine1,
        AddresLine2: this.AddresLine2,
        Zip: this.Zip,
        City: this.City,
        Country: this.Country,
        BirthDate: this.BirthDate,
        Nationality: this.Nationality,
        Height: parseFloat(this.Height),
        ShoeSize: parseInt(this.ShoeSize),
        HairColor: this.HairColor,
        EyeColor: this.EyeColor,
        Comments: this.Comments,
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
          if (response.status < 200 || response.status > 299) {
            alert("Validation error");
          } else {
            alert("The user got added");
          }
        })
        .catch((response) => {
          console.log("ERROR", response);
          alert("The user failed to be added");
        });

      this.Account = "";
      this.FirstName = "";
      this.LastName = "";
      this.Email = "";
      this.Password = "";
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
.logo {
  width: 40%;
}

.standardText {
  font-size: 22px;
  font-style: italic;
  font-weight: bold;
}

.CMStyle {
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
