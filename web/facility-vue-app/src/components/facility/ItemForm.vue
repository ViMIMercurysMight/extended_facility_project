<template>
    <div class="card">
        <div class="mr-1">
            <h1>{{title}}</h1>
        </div>
            <form v-on:submit.prevent='callback( innerItem )'>

                <div class='form-group ta-left m-1'>
                    <label class="form-label float-left" for="facilityName"> Name      </label>
                    <input class='form-control' type="text" v-model="innerItem.Name" id="facilityName" required placeholder="Enter Name" />
                </div>
                <div class='form-group ta-left m-1'>
                    <label class="form-label" for="facilityAddress"> Address  </label>
                    <input class='form-control' type='text' v-model='innerItem.Address' id="facilityAddress" required placeholder="Enter Address" />
                </div>
                <div class='form-group ta-left m-1'>
                    <label class="form-label" for="facilityPhone"> Phone </label>
                    <input class='form-control' type='text' v-model='innerItem.PhoneNumber' id="facilityPhone" required placeholder="Enter Phone" />
                </div>


                <div class='form-group ta-left m-1'>
                    <label class="form-label" for="facilityEmail"> Email  </label>
                    <input class='form-control' type="email" v-model='innerItem.Email' id="facilityEmail" required placeholder="Enter Email" />
                </div>

                <div v-if="statusDisplay" class='form-group ta-left m-1'>
                    <label class="form-label" for="facilityStatus">
                        Status
                    </label>

                    <select class='form-control' id="facilityStatus" v-model="innerItem.FacilityStatusId">
                        <option v-for="status in this.$store.state.Facility.statusesList" :value='status.id' :key="status.id"> {{ status.name  }} </option>
                    </select>

                </div>
                <button 
                        type="submit"
                        class='btn btn-success float-left w-100'>
                    Save
                </button>
            </form>

    </div>
</template>






<script lang="ts">
    import { defineComponent } from 'vue';

    export default defineComponent({
        name: "item-form",
        props: ["item", 'callback', "statusDisplay", "title"],

        data() {
            return {
                innerItem: {
                    Name: this.item.name,
                    Address: this.item.address,
                    PhoneNumber: this.item.phoneNumber,
                    Email: this.item.email,
                    FacilityStatusId: this.item.facilityStatusId,
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


    .fade-enter-active, .fade-leave-active {
        transition: opacity .5s;
    }

    .fade-enter, .fade-leave-to /* .fade-leave-active до версии 2.1.8 */ {
        opacity: 0;
    }
</style>




