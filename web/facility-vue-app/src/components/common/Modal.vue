<template>
<div class="modal fade" id="removeModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title" id="exampleModalLabel">Modal title</h5>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            </div>
            <div class="modal-body">
                {{message}}
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-secondary" v-on:click="close">Close</button>
                <button type="button" class="btn btn-primary" v-on:click="save">Save changes</button>
            </div>
        </div>
    </div>
</div>
</template>



<script lang="ts">
    import { defineComponent } from 'vue';
import { SET_MODAL_DISPLAY } from '../../store/MutationTypes';


    export default defineComponent({
        name: "modal",
        props: ['message', 'data', 'modalCallback'],

        methods: {
            save: function () {
                this.modalCallback(this.$store.state.modalData);
                setTimeout(() => this.$store.commit(SET_MODAL_DISPLAY, false), 50);
            },

            close: function () {

                setTimeout(() => this.$store.commit(SET_MODAL_DISPLAY, false), 50);
            }
        }
    });


</script>


<style lang="css">
    modal-static {
    
        width: 500px;
        height : 500px;
    
    }
</style>