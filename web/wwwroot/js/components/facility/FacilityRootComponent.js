import ItemForm  from "./ItemForm"  ;
import Table     from "./Table"     ;
import TableItem from "./TableItem" ;


export default {

    template: `
       <facility-list
            :items                = 'pageItems'
            :page-count           = 'pageCount'
            :change-page-callback = 'changePage'
            :update-callback      = 'showUpdateForm'
            :create-callback      = 'showCreateForm'
            :remove-callback      = 'remove' >
       </facility-list>


        <item-form
                v-show                  = 'isUpdateNow'
                :item                   = 'updateItem'
                :statuses               = 'statusesList'
                v-bind:status-display   = 'true'
                :callback               = 'update'>
        </item-form>


        <item-form
                v-show                  = 'isCreateNow'
                :item                   = '{}'
                :statuses               = 'statusesList'
                v-bind:status-display   = 'false'
                :callback               = "create">
         </item-form>

`,

    components: {
        "item-form"     : ItemForm,
        "facility-list" : Table,
        "facility-item" : TableItem
    }

};