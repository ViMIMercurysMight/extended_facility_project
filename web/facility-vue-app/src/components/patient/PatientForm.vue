<template>
    <div class="card">
        <div class="card-body">
            <div class="mr-1 card-title">
                <h1>{{title}}</h1>
            </div>
            <form v-on:submit.prevent='callback( innerItem )'>
                <div class='form-group ta-left m-1'>
                    <label for="patientFirstName" class="form-label"> First Name </label>
                    <input class='form-control' type="text" v-model="innerItem.FirstName" id="patientFirstName" required placeholder="Enter First Name" />
                </div>

                <div class='form-group ta-left m-1'>
                    <label for="patientLastName" class="form-label"> Last Name     </label>
                    <input class='form-control' type="text" v-model="innerItem.LastName" id="patientLastName" required placeholder="Enter Last Name" />
                </div>

                <div class='form-group ta-left m-1'>
                    <label for="dateOfBirth" class="form-label"> Date Of Birth    </label>
                    <input class='form-control' type="date" v-model="innerItem.DateOfBirth" id="dateOfBirth" required />
                </div>


                <div v-if="facilityDisplay" class='form-group ta-left m-1'>
                    <label class="form-label" for="patientFacility">
                        Facilities
                    </label>

                    <select class='form-control' v-model="innerItem.FacilityId" id="patientFacility">
                        <option v-for="facility in this.$store.state.Patient.facilitiList" :value='facility.id' :key="facility.id"> {{ facility.name  }} </option>
                    </select>

                </div>
                <div>
                    <button type="submit"
                            class='btn btn-success float-left w-auto'>
                        Save
                    </button>
                </div>
              
            </form>
        </div>  
    </div>
</template>






<script lang="ts">
    import { defineComponent } from 'vue';

    export default defineComponent({
        name: "patient-form",
        props: ["item", 'callback', "facilityDisplay", "title"],

        data() {
            return {
                innerItem: {
                    FirstName: this.item.firstName,
                    LastName: this.item.lastName,
                    DateOfBirth: this.item.dateOfBirth,
                    FacilityId: this.item.facilityId,
                    Id: this.item.id,
                }
            }
        }
    });

</script>





<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">

    .ta-left {
        text-align: left;
    }


    @media screen and (max-width:760px) {
        .card {
            width: 100%;
          
        }
    }


    input:invalid {
        border-color: red;
    }

    input:valid {
        border-color: green;
    }


</style>






