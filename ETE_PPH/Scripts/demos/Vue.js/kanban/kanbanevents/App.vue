<template>
    <div>
        <JqxKanban @itemMoved="myKanbanOnItemMoved($event)"
                   @columnCollapsed="myKanbanOnColumnCollapsed($event)"
                   @columnExpanded="myKanbanOnColumnExpanded($event)"
                   @itemAttrClicked="myKanbanOnItemAttrClicked($event)"
                   @columnAttrClicked="myKanbanOnColumnAttrClicked($event)"
                   :width="getWidth" :source="dataAdapter" :columns="columns"
                   :resources="resourcesAdapterFunc()">
        </JqxKanban>
        <div ref="myLog"></div>
    </div>
</template>
<script>
    import JqxKanban from "jqwidgets-scripts/jqwidgets-vue/vue_jqxkanban.vue";

    export default {
        components: {
            JqxKanban,
        },
        data: function () {
            return {
                getWidth: '90%',
                dataAdapter: new jqx.dataAdapter(this.source),
                columns: [
                    { text: 'Backlog', dataField: 'new' },
                    { text: 'In Progress', dataField: 'work' },
                    { text: 'Done', dataField: 'done' }
                ]
            }
        },
        beforeCreate: function () {
            this.log = [];

            const fields = [
                { name: 'id', type: 'string' },
                { name: 'status', map: 'state', type: 'string' },
                { name: 'text', map: 'label', type: 'string' },
                { name: 'tags', type: 'string' },
                { name: 'color', map: 'hex', type: 'string' },
                { name: 'resourceId', type: 'number' }
            ];

            this.source = {
                localData: [
                    { id: '1161', state: 'new', label: 'Make a new Dashboard', tags: 'dashboard', hex: '#36c7d0', resourceId: 3 },
                    { id: '1645', state: 'work', label: 'Prepare new release', tags: 'release', hex: '#ff7878', resourceId: 1 },
                    { id: '9213', state: 'new', label: 'One item added to the cart', tags: 'cart', hex: '#96c443', resourceId: 3 },
                    { id: '6546', state: 'done', label: 'Edit Item Price', tags: 'price, edit', hex: '#ff7878', resourceId: 4 },
                    { id: '9034', state: 'new', label: 'Login 404 issue', tags: 'issue, login', hex: '#96c443' }
                ],
                dataType: 'array',
                dataFields: fields
            };
        },
        methods: {
            resourcesAdapterFunc: function () {
                let resourcesSource =
                    {
                        localData: [
                            { id: 0, name: 'No name', image: '../../../images/common.png', common: true },
                            { id: 1, name: 'Andrew Fuller', image: '../../../images/andrew.png' },
                            { id: 2, name: 'Janet Leverling', image: '../../../images/janet.png' },
                            { id: 3, name: 'Steven Buchanan', image: '../../../images/steven.png' },
                            { id: 4, name: 'Nancy Davolio', image: '../../../images/nancy.png' },
                            { id: 5, name: 'Michael Buchanan', image: '../../../images/Michael.png' },
                            { id: 6, name: 'Margaret Buchanan', image: '../../../images/margaret.png' },
                            { id: 7, name: 'Robert Buchanan', image: '../../../images/robert.png' },
                            { id: 8, name: 'Laura Buchanan', image: '../../../images/Laura.png' },
                            { id: 9, name: 'Laura Buchanan', image: '../../../images/Anne.png' }
                        ],
                        dataType: 'array',
                        dataFields: [
                            { name: 'id', type: 'number' },
                            { name: 'name', type: 'string' },
                            { name: 'image', type: 'string' },
                            { name: 'common', type: 'boolean' }
                        ]
                    };
                let resourcesDataAdapter = new jqx.dataAdapter(resourcesSource);
                return resourcesDataAdapter;
            },
            updateLog: function() {
                let count = 0;
                let str = '';
                for (let i = this.log.length - 1; i >= 0; i--) {
                    str += this.log[i] + '<br/>';
                    count++;
                    if (count > 10)
                        break;
                }
                this.$refs.myLog.innerHTML = str;
            },
            myKanbanOnItemMoved: function(event) {
                let args = event.args;
                let itemId = args.itemId;
                let oldParentId = args.oldParentId;
                let newParentId = args.newParentId;
                let itemData = args.itemData;
                let oldColumn = args.oldColumn;
                let newColumn = args.newColumn;
                this.log.push('itemMoved is raised');
                this.updateLog();
            },
            myKanbanOnColumnCollapsed: function(event) {
                let args = event.args;
                let column = args.column;
                this.log.push('columnCollapsed is raised');
                this.updateLog();
            },
            myKanbanOnColumnExpanded: function(event) {
                let args = event.args;
                let column = args.column;
                this.log.push('columnExpanded is raised');
                this.updateLog();
            },
            myKanbanOnItemAttrClicked: function(event) {
                let args = event.args;
                let itemId = args.itemId;
                let attribute = args.attribute; // template, colorStatus, content, keyword, text, avatar
                this.log.push('itemAttrClicked is raised');
                this.updateLog();
            },
            myKanbanOnColumnAttrClicked: function(event) {
                let args = event.args;
                let column = args.column;
                let cancelToggle = args.cancelToggle; // false by default. Set to true to cancel toggling dynamically.
                let attribute = args.attribute; // title, button
                this.log.push('columnAttrClicked is raised');
                this.updateLog();
            }
        }
    }
</script>

<style>
</style>
