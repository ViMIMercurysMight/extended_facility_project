<template>
    <facility-list :items='pageItems'
                   :page-count='pageCount'
                   :change-page-callback='changePage'
                   :update-callback='showUpdateForm'
                   :create-callback='showCreateForm'
                   :remove-callback='remove'>
    </facility-list>


    <item-form v-show='isUpdateNow'
               :item='updateItem'
               :statuses='statusesList'
               v-bind:status-display='true'
               :callback='update'>
    </item-form>


    <item-form v-show='isCreateNow'
               :item='{}'
               :statuses='statusesList'
               v-bind:status-display='false'
               :callback="create">
    </item-form>
</template>


<script lang="ts">
    import { defineComponent } from 'vue';


    import ItemForm  from "./ItemForm.vue";
    import Table     from "./Table.vue";
    import TableItem from "./TableItem.vue";


    export default defineComponent({
        name : "facility-root-component",
        
        components: {
            "item-form"    : ItemForm,
            "facility-list": Table,
            "facility-item": TableItem
        }
    });

</script>

