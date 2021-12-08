<template>
    <div class="d-flex flex-column w-100 h-100 align-items-center">
        <h1 class="w-50">Create New Model</h1>
        <form class="w-50" @submit.prevent="handleSubmit">
            <div class="form-group">
                <label for="firstName">
                    First Name:
                </label>
                <input
                    type="text"
                    class="form-control"
                    name="firstName"
                    placeholder="First Name"
                    v-model="supermodel.firstName"
                />
            </div>
            <div class="form-group">
                <label for="lastName">
                    Last Name:
                </label>
                <input
                    type="text"
                    class="form-control"
                    name="lastName"
                    placeholder="Last Name"
                    v-model="supermodel.lastName"
                />
            </div>
            <div class="form-group">
                <label for="email">
                    Email:
                </label>
                <input
                    type="text"
                    class="form-control"
                    name="email"
                    placeholder="email Address"
                    v-model="supermodel.email"
                />
            </div>
            <div class="form-group">
                <label for="lastName">
                    Phone Number:
                </label>
                <input
                    type="text"
                    class="form-control"
                    name="PhoneNumber"
                    placeholder="Phone Number"
                    v-model="supermodel.phoneNo"
                />
            </div>
            <div class="form-group">
                <label for="addresLine1">
                    Address Line 1:
                </label>
                <input
                    type="text"
                    class="form-control"
                    name="addresLine1"
                    placeholder="Address 1"
                    v-model="supermodel.addresLine1"
                />
            </div>
            <div class="form-group">
                <label for="addresLine2">
                    Address Line 2:
                </label>
                <input
                    type="text"
                    class="form-control"
                    name="addresLine2"
                    placeholder="Address 2"
                    v-model="supermodel.addresLine2"
                />
            </div>
            <div class="form-group">
                <label for="zip">
                    Zip Code:
                </label>
                <input
                    type="text"
                    class="form-control"
                    name="zip"
                    placeholder="zip"
                    v-model="supermodel.zip"
                />
            </div>
            <div class="form-group">
                <label for="city">
                    City:
                </label>
                <input
                    type="text"
                    class="form-control"
                    name="city"
                    placeholder="city"
                    v-model="supermodel.city"
                />
            </div>
            <div class="form-group">
                <label for="country">
                    Country:
                </label>
                <input
                    type="text"
                    class="form-control"
                    name="country"
                    placeholder="country"
                    v-model="supermodel.country"
                />
            </div>
            <div class="form-group">
                <label for="birthDate">
                    Birth Date:
                </label>
                <input
                    type="date"
                    class="form-control"
                    name="birthDate"
                    v-model="supermodel.birthDate"
                />
            </div>
            <div class="form-group">
                <label for="nationality">
                    Nationality:
                </label>
                <input
                    type="text"
                    class="form-control"
                    name="nationality"
                    placeholder="nationality"
                    v-model="supermodel.nationality"
                />
            </div>
            <div class="form-group">
                <label for="height">
                    Height:
                </label>
                <input
                    type="number"
                    class="form-control"
                    name="height"
                    placeholder="height"
                    v-model="supermodel.height"
                />
            </div>
            <div class="form-group">
                <label for="shoeSize">
                    Shoe Size:
                </label>
                <input
                    type="number"
                    class="form-control"
                    name="shoeSize"
                    placeholder="Shoe Size"
                    v-model="supermodel.shoeSize"
                />
            </div>
            <div class="form-group">
                <label for="hairColor">
                    Hair Color:
                </label>
                <input
                    type="text"
                    class="form-control"
                    name="hairColor"
                    placeholder="Hair Color"
                    v-model="supermodel.hairColor"
                />
            </div>
            <div class="form-group">
                <label for="eyeColor">
                    Eye Color:
                </label>
                <input
                    type="text"
                    class="form-control"
                    name="eyeColor"
                    placeholder="Eye Color"
                    v-model="supermodel.eyeColor"
                />
            </div>
            <div class="form-group">
                <label for="comments">
                    Comments:
                </label>
                <input
                    type="text"
                    class="form-control"
                    name="comments"
                    placeholder="comments"
                    v-model="supermodel.comments"
                />
            </div>
            <div class="form-group">
                <label for="password">
                    Password:
                </label>
                <input
                    type="text"
                    class="form-control"
                    name="password"
                    placeholder="Password"
                    v-model="supermodel.password"
                />
            </div>
            <button class="btn btn-primary" type="submit">Add Model</button>
        </form>
    </div>
</template>

<script>
import { post } from "@/shared/fetch";
import router from "@/router";

export default {
    data() {
        return {
            supermodel: {
                firstName: "",
                lastName: "",
                email: "",
                phoneNo: "",
                addresLine1: "",
                addresLine2: "",
                zip: "",
                city: "",
                country: "",
                birthDate: "",
                nationality: "",
                height: 0,
                shoeSize: 0,
                hairColor: "",
                eyeColor: "",
                comments: "",
            },
            failed: false,
        };
    },
    methods: {
        async handleSubmit() {
            this.supermodel.height = parseInt(this.supermodel.height);
            this.supermodel.shoeSize = parseInt(this.supermodel.shoeSize);
            let response = await post("api/Models", this.supermodel);
            console.log(response);
            if (response.status === 201) {
                this.failed = false;
                router.push({ name: "Home" });
            } else {
                this.failed = true;
            }
        },
    },
};
</script>
