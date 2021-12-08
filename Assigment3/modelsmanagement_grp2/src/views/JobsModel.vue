<template>
    <div class="jobs">
        <p>
            Jobs
        </p>
    </div>

    <table class="table-admin table-bordered" id="job-app">
        <thead>
            <tr>
                <th>
                    Model
                </th>
                <th>
                    Jobs
                </th>
            </tr>
        </thead>
        <tbody>
            <tr v-for="job in jobs">
                <td>
                    {{ job.model }}
                </td>
                <td>
                    {{ job.job }}
                </td>
            </tr>

        </tbody>
    </table>
</template>


<script>
    var url = "https://localhost:44368/api/Jobs";
    export default {
        data() {
            return {
                jobs: [],
            };
        },
        methods: {
            mounted() {
                var promise = fetch(url,
                    {
                        method: 'GET'
                    });

                promise
                    .then(response => response.json())
                    .then(response => {
                        console.log("GOOD", response);

                        // indsætte data i tabel:
                        this.jobs = response;

                    })
                    .catch(response => {
                        console.log("ERROR", response);
                    });
            }
        }

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
        margin-left: 53% !important;
    }
</style>
