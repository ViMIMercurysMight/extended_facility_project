Vue.component('item-form', {

    props: ["item", 'callback', "statuses", "statusDisplay"],

    template:
        `
                <div>
                <form class='form'>
                            <div class='form-group'>
                         <label> Name    <input class='form-control' type="text" v-model:value='item.Name'/>        </label>
                            </div>
                            <div class='form-group'>
                         <label> Address <input class='form-control' type='text' v-model:value='item.Address'/>     </label>
                            </div>
                            <div class='form-group'>
                         <label> Phone   <input class='form-control' type='text' v-model:value='item.PhoneNumber'/> </label>
                            </div>
                            <div class='form-group'>
                         <label> Email   <input class='form-control' type="email"  v-model:value='item.Email'/>     </label>
                            </div>
                
                        <div v-if="statusDisplay" class='form-group'>
                            <label> Status 
                                    <select class='form-control' v-model='item.FacilityStatusId'>
                                        <option v-for="status in statuses" :value='status.Id' > {{ status.Name  }} </option> 
                                    </select>
                            </label>
                        </div>        
              </form>
              <button v-on:click='callback( {
                        FacilityStatusId : item.FacilityStatusId, 
                        Id: item.Id,
                        Name : item.Name,
                        Address : item.Address,
                        PhoneNumber : item.PhoneNumber,
                        Email : item.Email } 
              )'
                      class='btn btn-success'
            > Commit </button>
              </div>
          
                `


});
