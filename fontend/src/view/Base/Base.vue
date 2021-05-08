<script>
export default {
    name: "Base",
    data(){
        return{
            api: null,
            dataSource: [],
            MasterID: null,
            property: null,
        }
    },
    props:{
        callBack: null,
    },
    methods: {
        getData(){
            var me = this;
            if(me.MasterID){
                this.api. getByPropertyValue(this.property,this.MasterID).then(res => {
                me.dataSource = res.data;
            })
            }
            else{
                this.api.getAll().then(res => {
                    me.dataSource = res.data;
                });
            }
        },
        save(data){
            var me = this;
            if(data['State'] == 1)
            {
                this.api.insert(data).then(res => {
                    me.getData();
                });
            }
            else
            {

                this.api.update(data).then(res => {
                    me.getData();
                });
            }
        },
        deleteById(id){
            var me = this;
            this.api.delete(id).then(res => {
                me.getData();
            });
        },
        getById(id){
            var me = this;
            this.api.getById(id).then(res => {
                me.dataSource = res.data;
            })
        },
        getByPropertyValue(property,value){
            var me = this;
            this.api. getByPropertyValue(property,value).then(res => {
                me.dataSource = res.data;
            })
        }
    }
}
</script>