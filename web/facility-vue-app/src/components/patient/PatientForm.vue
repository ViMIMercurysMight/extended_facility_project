<template>
    <div class="card">
        <form class='form'>
            <div class='form-group'>
                <label for="patientFirstName" class="form-label"> First Name </label>
                <input class='form-control' type="text" v-model="innerItem.FirstName" id="patientFirstName" required placeholder="Enter First Name"/>        
            </div>

            <div class='form-group'>
                <label for="patientLastName" class="form-label"> Last Name     </label>
                <input class='form-control' type="text" v-model="innerItem.LastName" id="patientLastName" required placeholder="Enter Last Name" />     
            </div>

            <div class='form-group'>
                <label for="dateOfBirth" class="form-label"> Date Of Birth    </label>
                <input class='form-control' type="date" v-model="innerItem.DateOfBirth" id="dateOfBirth" required />
            </div>

      
            <div v-if="facilityDisplay" class='form-group'>
                <label class="form-label" for="patientFacility">
                    Facilities
                </label>

                <select class='form-control' v-model="innerItem.FacilityId" id="patientFacility">
                  <option v-for="facility in this.$store.state.Patient.facilitiList" :value='facility.id' :key="facility.id"> {{ facility.name  }} </option>
                </select>

            </div>
        </form>
        <button v-on:click='callback( innerItem )'
                class='btn btn-success float-left'>
            Commit
        </button>
    </div>
</template>






<script lang="ts">
    import { defineComponent } from 'vue';

    export default defineComponent({
        name: "patient-form",
        props: ["item", 'callback', "facilityDisplay"],

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

