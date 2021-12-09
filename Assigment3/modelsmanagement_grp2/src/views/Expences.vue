<template>
    <div>
        <img alt="Vue logo" src="../assets/logo.png" class="logo" />
    </div>
    <p class="standardText">Add an expence to a chosen job </p>
    <div class="container">
        <div class="row justify-content-center ModelExpence">
            <div class="col-md-2">
                <label for="ExpenceText">Expence: </label>
            </div>
            <div class="col-md-4">
                <input type="text"
                       v-model="expenceText"
                       name="ExpenceText"
                       required
                       class="inputStyle" />
            </div>
        </div>
        <div class="row justify-content-center ModelExpence">
            <div class="col-md-2">
                <label for="Date">Date (YYYY/MM/DD): </label>
            </div>
            <div class="col-md-4">
                <input type="text"
                       v-model="date"
                       name="Date"
                       required
                       class="inputStyle" />
            </div>
        </div>
        <div class="row justify-content-center ModelExpence">
            <div class="col-md-2">
                <label for="Amount">Amount: </label>
            </div>
            <div class="col-md-4">
                <input type="text"
                       v-model="amount"
                       name="Amount"
                       required
                       class="inputStyle" />
            </div>
        </div>
        <div class="row justify-content-center ModelExpence">
            <div class="col-md-2">
                <label for="Job">Job: </label>
            </div>
            <div class="col-md-4">
                <select v-model="jobId">
                    <option v-for="job in jobs" v-bind:key="job.efJobId" v-bind:value="job.efJobId">
                        {{ job.customer }}
                    </option>
                </select>
            </div>
            </div>
        </div>

    <div class="row justify-content-center ModelExpence">
        <div class="col-md-6">
            <input type="button"
                   value="Add Expence"
                   v-on:click="addExpence"
                   class="buttonStyle" />
        </div>
    </div>
            <!--<div class="row justify-content-center ModelExpence">
        <table>
            <thead>
                <tr>
                    <td>
                        Choose job to add expences to
                    </td>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td v-for="(expence, expenceIndex) in expences" :key="expenceIndex">
                        <a href="#" v-on:click="addExpenceToJob(expence.modelId, expence.jobId)">Add expence {{expence.amount}} </a>
                    </td>
                </tr>
            </tbody>
        </table>
        </div>
    </div>-->
</template>

<script>
    var url = "https://localhost:44368/api/Expences";
    export default {
        data() {
            return {
                expenceText: "",
                date: "",
                amount: "",
                expence: [],
                jobs: [],
                jobId: "",
            };
        },
        mounted() {
            var Joburl = "https://localhost:44368/api/jobs";
            var promise = fetch(Joburl, {
                method: "GET",
                headers: {
                    "content-type": "application/json",
                    Authorization: "Bearer " + localStorage.getItem("token"),
                },
            });

            promise
                .then((response) => response.json())
                .then((response) => {
                    console.log("GOOD", response);

                    // inds�tte data i tabel:
                    console.log(JSON.stringify(response));
                    this.jobs = response;
                })
                .catch((response) => {
                    console.log("ERROR", response);
                });
        },
        methods: {
            addExpenceToJob() {
                var bodyData = {
                    expenceText: this.expenceText,
                    date: this.date,
                    amount: this.amount,
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
.logo {
    width: 40%;
}

.standardText {
    font-size: 22px;
    font-style: italic;
    font-weight: bold;
}

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
