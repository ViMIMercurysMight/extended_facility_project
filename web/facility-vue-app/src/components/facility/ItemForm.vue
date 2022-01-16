<template>
    <div class="card">
        <form class='form'>
            <div class='form-group'>
                <label class="form-label" for="facilityName"> Name      </label>
                <input class='form-control' type="text" v-model="innerItem.Name" id="facilityName" required placeholder="Enter Name"/>    
            </div>
            <div class='form-group'>
                <label class="form-label" for="facilityAddress"> Address  </label>
                <input class='form-control' type='text' v-model='innerItem.Address' id="facilityAddress" required placeholder="Enter Address"/> 
            </div>
            <div class='form-group'>
                <label class="form-label" for="facilityPhone"> Phone </label>
                <input class='form-control' type='text' v-model='innerItem.PhoneNumber' id="facilityPhone" required placeholder="Enter Phone"/> 
            </div>
            <div class='form-group'>
                <label class="form-label" for="facilityEmail"> Email  </label>
                <input class='form-control' type="email" v-model='innerItem.Email' id="facilityEmail" required placeholder="Enter Email"/>
            </div>

            <div v-if="statusDisplay" class='form-group'>
                <label class="form-label" for="facilityStatus">
                    Status
                </label>
                
                <select class='form-control' id="facilityStatus" v-model="innerItem.FacilityStatusId">
                  <option v-for="status in this.$store.state.Facility.statusesList" :value='status.id'  :key="status.id"> {{ status.name  }} </option>
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
        name : "item-form",
        props: ["item", 'callback', "statusDisplay"],

        data() {
            return {
                innerItem : {
                    Name: this.item.name,
                    Address: this.item.address,
                    PhoneNumber: this.item.phoneNumber,
                    Email: this.item.email,
                    FacilityStatusId: this.item.facilityStatusId,
                    Id :this.item.id,
                }
            }
        }
    });

</script>

