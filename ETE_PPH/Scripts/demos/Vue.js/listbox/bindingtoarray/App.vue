<template>
    <div>
        <JqxListBox @select="select($event)"
                    :source="source"
                    :height="300"
                    :width="300">
        </JqxListBox>

        <div style="font-size: 13px; font-family: Verdana;" ref="selectionlog">
        </div>
    </div>
</template>
<script>
    import JqxListBox from "jqwidgets-scripts/jqwidgets-vue/vue_jqxlistbox.vue";

    export default {
        components: {
            JqxListBox
        },
        data: function () {
            return {
                source: [{
                    label: "Peppermint Hot Chocolate",
                    value: "Chocolate Beverage",
                    group: "Hot Chocolate"
                }, {
                    label: "Salted Caramel Hot Chocolate",
                    value: "Chocolate Beverage",
                    group: "Hot Chocolate"
                }, {
                    label: "White Hot Chocolate",
                    value: "Chocolate Beverage",
                    group: "Hot Chocolate"
                }, {
                    label: "Caffe Americano",
                    value: "Espresso Beverage",
                    group: "Espresso"
                }, {
                    label: "Caffe Latte",
                    value: "Espresso Beverage",
                    group: "Espresso"
                }, {
                    label: "Caffe Mocha",
                    value: "Espresso Beverage",
                    group: "Espresso"
                }, {
                    label: "Cappuccino",
                    value: "Espresso Beverage",
                    group: "Espresso"
                }, {
                    label: "Caramel Brulee Latte",
                    value: "Espresso Beverage",
                    group: "Espresso"
                }, {
                    label: "Caramel Macchiato",
                    value: "Espresso Beverage",
                    group: "Espresso"
                }, {
                    label: "Peppermint Hot Chocolate",
                    value: "Espresso Beverage",
                    group: "Espresso"
                }, {
                    label: "Cinnamon Dolce Latte",
                    value: "Espresso Beverage",
                    group: "Espresso"
                }, {
                    label: "Eggnog Latte",
                    value: "Espresso Beverage",
                    group: "Espresso"
                }, {
                    label: "Espresso",
                    value: "Espresso Beverage",
                    group: "Espresso"
                }, {
                    label: "Espresso Con Panna",
                    value: "Espresso Beverage",
                    group: "Espresso"
                }, {
                    label: "Espresso Macchiato",
                    value: "Espresso Beverage",
                    group: "Espresso"
                }, {
                    label: "Flavored Latte",
                    value: "Espresso Beverage",
                    group: "Espresso"
                }, {
                    label: "Gingerbread Latte",
                    value: "Espresso Beverage",
                    group: "Espresso"
                }, {
                    label: "White Chocolate Mocha",
                    value: "Espresso Beverage",
                    group: "Espresso"
                }, {
                    label: "Skinny Peppermint Mocha",
                    value: "Espresso Beverage",
                    group: "Espresso"
                }, {
                    label: "Skinny Flavored Latte",
                    value: "Espresso Beverage",
                    group: "Espresso"
                }, {
                    label: "Pumpkin Spice Latte",
                    value: "Espresso Beverage",
                    group: "Espresso"
                }, {
                    label: "Caffe Vanilla Frappuccino",
                    value: "Frappuccino Blended Beverage",
                    group: "Frappuccino"
                }, {
                    label: "Caffe Vanilla Frappuccino Light",
                    value: "Frappuccino Blended Beverage",
                    group: "Frappuccino"
                }, {
                    label: "Caramel Brulee Frappuccino",
                    value: "Frappuccino Blended Beverage",
                    group: "Frappuccino"
                }, {
                    label: "Caramel Brulee Frappuccino Light",
                    value: "Frappuccino Blended Beverage",
                    group: "Frappuccino"
                }, {
                    label: "Eggnog Frappuccino",
                    value: "Frappuccino Blended Beverage",
                    group: "Frappuccino"
                }, {
                    label: "Mocha Frappuccino",
                    value: "Frappuccino Blended Beverage",
                    group: "Frappuccino"
                }, {
                    label: "Tazo Green Tea Creme Frappuccino",
                    value: "Frappuccino Blended Beverage",
                    group: "Frappuccino"
                }]
            }
        },
        methods: {
            select: function (event) {
                if (event.args) {
                    let item = event.args.item;
                    if (item) {
                        let valueElement = document.createElement('div');
                        let labelElement = document.createElement('div');

                        valueElement.innerHTML = 'Value: ' + item.value;
                        labelElement.innerHTML = 'Label: ' + item.label;

                        let selectionLog = this.$refs.selectionlog;

                        selectionLog.innerHTML = '';

                        selectionLog.appendChild(labelElement);
                        selectionLog.appendChild(valueElement);
                    }
                }
            }
        }
    }
</script>

<style>
</style>
