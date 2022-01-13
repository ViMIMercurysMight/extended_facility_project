<template>
    <div>
        <form class='form'>
            <div class='form-group'>
                <label> First Name    <input class='form-control' type="text" v-model="innerItem.FirstName" required placeholder="Enter First Name"/>        </label>
            </div>

            <div class='form-group'>
                <label> Last Name    <input class='form-control' type="text" v-model="innerItem.LastName" required placeholder="Enter Last Name" />        </label>
            </div>

            <div class='form-group'>
                <label> Date Of Birth    <input class='form-control' type="date" v-model="innerItem.DateOfBirth" required />        </label>
            </div>

      
            <div v-if="facilityDisplay" class='form-group'>
                <label>
                    Facilities
                    <select class='form-control' v-model="innerItem.FacilityId">
                        <option v-for="facility in this.$store.state.Patient.facilitiList" :value='facility.id' :key="facility.id"> {{ facility.name  }} </option>
                    </select>
                </label>
            </div>
        </form>
        <button v-on:click='callback( innerItem )'
                class='btn btn-success'>
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

