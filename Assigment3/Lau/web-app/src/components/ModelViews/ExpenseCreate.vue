<template>
<div>
    <b-form @submit.prevent="onSubmit" @reset="onReset" v-if="show">
      <b-form-group
        id="input-group-1"
        label="Date:"
        label-for="input-1"
      >
        <b-form-input
          id="input-1"
          v-model="form.date"
          type="date"
          required
          placeholder="Enter email"
        ></b-form-input>
      </b-form-group>

      <b-form-group id="input-group-2" label="Text:" label-for="input-2">
        <b-form-input
          id="input-2"
          v-model="form.text"
          required
          placeholder="Enter a description of the purchase"
        ></b-form-input>
      </b-form-group>

        <b-form-group id="input-group-3" label="Amount in DKK:" label-for="input-3">
        <b-form-input
          id="input-3"
          v-model="form.amount"
          required
          type="number"
        ></b-form-input>
      </b-form-group>
      
      


      <b-button type="submit" variant="primary">Submit</b-button>
      <h6>{{success}}</h6>
    </b-form>
  </div>


</template>

<script>

import { post } from "@/shared/fetch";
import decode from "@/shared/decode";

export default{
    data() {
        return{
            form:{
                modelId:'',
                jobId:'',
                date:'',
                text:'',
                amount:0
            },
            show: true,
            success : ''
        } 
    },
    created(){
        this.form.jobId = this.$route.params.id;
        const jwt = localStorage.getItem("jwt");
        const jwtDecoded = decode(jwt);
        this.form.modelId =  jwtDecoded.ModelId;
    },
    methods: {
        async onSubmit(){
            this.form.amount = parseInt(this.form.amount);
            this.form.modelId = parseInt(this.form.modelId);
            this.form.jobId = parseInt(this.form.jobId);

            console.log(this.form);
            let result = await post("api/expenses",this.form);
            if(result.status == 201)
            {
              this.$emit('success');
            }
            else
            {
                this.success = 'Something went wrong, please try again.'
            }
        },
        onReset(){

        }

        
    }
}

</script> 