<template>
    <div>
        <form class='form'>
            <div class='form-group'>
                <label> Name    <input class='form-control' type="text" v-model="innerItem.Name" required placeholder="Enter Name"/>        </label>
            </div>
            <div class='form-group'>
                <label> Address <input class='form-control' type='text' v-model='innerItem.Address' required placeholder="Enter Address"/>     </label>
            </div>
            <div class='form-group'>
                <label> Phone   <input class='form-control' type='text' v-model='innerItem.PhoneNumber' required placeholder="Enter Phone"/> </label>
            </div>
            <div class='form-group'>
                <label> Email   <input class='form-control' type="email" v-model='innerItem.Email' required placeholder="Enter Email"/>     </label>
            </div>

            <div v-if="statusDisplay" class='form-group'>
                <label>
                    Status
                    <select class='form-control' v-model="innerItem.FacilityStatusId">
                        <option v-for="status in this.$store.state.Facility.statusesList" :value='status.id'  :key="status.id"> {{ status.name  }} </option>
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

