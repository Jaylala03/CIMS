var TableAdvanced = function () {

    var initTable1 = function () {
        var table = $('#sample_1');

        /* Table tools samples: https://www.datatables.net/release-datatables/extras/TableTools/ */

        /* Set tabletools buttons and button container */

        $.extend(true, $.fn.DataTable.TableTools.classes, {
            
        });

        var oTable = table.dataTable({
            "aaSorting": [],
            "aLengthMenu": [
                [10, 15,20,-1],
                [10, 15,20,'All'] // change per page values here
            ],
            // set the initial value
            "iDisplayLength": -1,
            //"sScrollY": "200",
            //"bScrollCollapse": true,
            "sDom": "<'row'><'table-scrollable't>", // horizobtal scrollable datatable

            "bStateSave": true,
            "fnStateSave": function (oSettings, oData) {
                localStorage.setItem('DataTables_' + window.location.pathname, JSON.stringify(oData));
            },
            "fnStateLoad": function (oSettings) {
                var data = localStorage.getItem('DataTables_' + window.location.pathname);
                return JSON.parse(data);
            }
        });

        var tableWrapper = $('#sample_1_wrapper'); // datatable creates the table wrapper by adding with id {your_table_jd}_wrapper

        jQuery('.dataTables_filter input', tableWrapper).addClass("form-control input-small input-inline"); // modify table search input
        jQuery('.dataTables_length select', tableWrapper).addClass("form-control input-small"); // modify table per page dropdown
       // jQuery('.dataTables_length select', tableWrapper).select2(); // initialize select2 dropdown
    }

    var initTable2 = function () {
        var table = $('#sample_2');

        /* Table tools samples: https://www.datatables.net/release-datatables/extras/TableTools/ */

        /* Set tabletools buttons and button container */

        $.extend(true, $.fn.DataTable.TableTools.classes, {
            
        });

        var oTable = table.dataTable({
            
            "aaSorting": [],
            // set the initial value
            "iDisplayLength": -1,
            "sDom": "<'row' ><'table-scrollable't>", // horizobtal scrollable datatable

            "bStateSave": true,
            "fnStateSave": function (oSettings, oData) {
                localStorage.setItem('DataTables_' + window.location.pathname, JSON.stringify(oData));
            },
            "fnStateLoad": function (oSettings) {
                var data = localStorage.getItem('DataTables_' + window.location.pathname);
                return JSON.parse(data);
            }
           
        });

        var tableWrapper = $('#sample_2_wrapper'); // datatable creates the table wrapper by adding with id {your_table_jd}_wrapper

        jQuery('.dataTables_filter input', tableWrapper).addClass("form-control input-small input-inline"); // modify table search input
        jQuery('.dataTables_length select', tableWrapper).addClass("form-control input-small"); // modify table per page dropdown
        jQuery('.dataTables_length select', tableWrapper).select2(); // initialize select2 dropdown
    }

    var initTable3 = function () {
        var table = $('#sample_3');

        /* Table tools samples: https://www.datatables.net/release-datatables/extras/TableTools/ */

        /* Set tabletools buttons and button container */

        $.extend(true, $.fn.DataTable.TableTools.classes, {
            
        });

        var oTable = table.dataTable({
            "aaSorting": [],
            "aLengthMenu": [
                 [10, 15, 20, -1],
                 [10, 15, 20, 'All'] // change per page values here
            ],
            // set the initial value
            "iDisplayLength": -1,
            "sDom": "<'row' ><'table-scrollable't>", // horizobtal scrollable datatable

            "bStateSave": true,
            "fnStateSave": function (oSettings, oData) {
                localStorage.setItem('DataTables_' + window.location.pathname, JSON.stringify(oData));
            },
            "fnStateLoad": function (oSettings) {
                var data = localStorage.getItem('DataTables_' + window.location.pathname);
                return JSON.parse(data);
            }
        });

        var tableWrapper = $('#sample_3_wrapper'); // datatable creates the table wrapper by adding with id {your_table_jd}_wrapper

        jQuery('.dataTables_filter input', tableWrapper).addClass("form-control input-small input-inline"); // modify table search input
        jQuery('.dataTables_length select', tableWrapper).addClass("form-control input-small"); // modify table per page dropdown
        jQuery('.dataTables_length select', tableWrapper).select2(); // initialize select2 dropdown
    }

    var initTable4 = function () {
        var table = $('#sample_4');

        /* Table tools samples: https://www.datatables.net/release-datatables/extras/TableTools/ */

        /* Set tabletools buttons and button container */

        $.extend(true, $.fn.DataTable.TableTools.classes, {
           
        });

        var oTable = table.dataTable({
            "aaSorting": [],
            "aLengthMenu": [
                [10, 15, 20, -1],
                [10, 15, 20, 'All'] // change per page values here
            ],
            // set the initial value
            "iDisplayLength": -1,
            "sDom": "<'row' ><'table-scrollable't>", // horizobtal scrollable datatable

            "bStateSave": true,
            "fnStateSave": function (oSettings, oData) {
                localStorage.setItem('DataTables_' + window.location.pathname, JSON.stringify(oData));
            },
            "fnStateLoad": function (oSettings) {
                var data = localStorage.getItem('DataTables_' + window.location.pathname);
                return JSON.parse(data);
            }
        });

        var tableWrapper = $('#sample_4_wrapper'); // datatable creates the table wrapper by adding with id {your_table_jd}_wrapper

        jQuery('.dataTables_filter input', tableWrapper).addClass("form-control input-small input-inline"); // modify table search input
        jQuery('.dataTables_length select', tableWrapper).addClass("form-control input-small"); // modify table per page dropdown
        jQuery('.dataTables_length select', tableWrapper).select2(); // initialize select2 dropdown
    }

    var initTable5 = function () {
        var table = $('#assetTable');

        /* Table tools samples: https://www.datatables.net/release-datatables/extras/TableTools/ */

        /* Set tabletools buttons and button container */

        $.extend(true, $.fn.DataTable.TableTools.classes, {
            
        });

        var oTable = table.dataTable({
            "aaSorting": [],
            "aLengthMenu": [
                [10, 15, 20, -1],
                [10, 15, 20, 'All'] // change per page values here
            ],
            // set the initial value
            "iDisplayLength": -1,
            "sDom": "<'row' ><'table-scrollable't>", // horizobtal scrollable datatable

            "bStateSave": true,
            "fnStateSave": function (oSettings, oData) {
                localStorage.setItem('DataTables_' + window.location.pathname, JSON.stringify(oData));
            },
            "fnStateLoad": function (oSettings) {
                var data = localStorage.getItem('DataTables_' + window.location.pathname);
                return JSON.parse(data);
            }
        });

        var tableWrapper = $('#assetTable_wrapper'); // datatable creates the table wrapper by adding with id {your_table_jd}_wrapper

        jQuery('.dataTables_filter input', tableWrapper).addClass("form-control input-small input-inline"); // modify table search input
        jQuery('.dataTables_length select', tableWrapper).addClass("form-control input-small"); // modify table per page dropdown
        jQuery('.dataTables_length select', tableWrapper).select2(); // initialize select2 dropdown
    }


    var initTable6 = function () {
        var table = $('#sample_6');

        /* Table tools samples: https://www.datatables.net/release-datatables/extras/TableTools/ */

        /* Set tabletools buttons and button container */

        $.extend(true, $.fn.DataTable.TableTools.classes, {
            
        });

        var oTable = table.dataTable({
            "aaSorting": [],
            "aLengthMenu": [
                 [10, 15, 20, -1],
                 [10, 15, 20, 'All'] // change per page values here
            ],
            // set the initial value
            "iDisplayLength": -1,
            "sDom": "<'row' ><'table-scrollable't>", // horizobtal scrollable datatable

            "bStateSave": true,
            "fnStateSave": function (oSettings, oData) {
                localStorage.setItem('DataTables_' + window.location.pathname, JSON.stringify(oData));
            },
            "fnStateLoad": function (oSettings) {
                var data = localStorage.getItem('DataTables_' + window.location.pathname);
                return JSON.parse(data);
            }
        });

        var tableWrapper = $('#sample_6_wrapper'); // datatable creates the table wrapper by adding with id {your_table_jd}_wrapper

        jQuery('.dataTables_filter input', tableWrapper).addClass("form-control input-small input-inline"); // modify table search input
        jQuery('.dataTables_length select', tableWrapper).addClass("form-control input-small"); // modify table per page dropdown
        jQuery('.dataTables_length select', tableWrapper).select2(); // initialize select2 dropdown
    }

    var initTable7 = function () {
        var table = $('#sample_7');

        /* Table tools samples: https://www.datatables.net/release-datatables/extras/TableTools/ */

        /* Set tabletools buttons and button container */

        $.extend(true, $.fn.DataTable.TableTools.classes, {
            
        });

        var oTable = table.dataTable({
            "aaSorting": [],
            "aLengthMenu": [
                [10, 15, 20, -1],
                [10, 15, 20, 'All'] // change per page values here
            ],
            // set the initial value
            "iDisplayLength": -1,
            "sDom": "<'row' ><'table-scrollable't>", // horizobtal scrollable datatable

            "bStateSave": true,
            "fnStateSave": function (oSettings, oData) {
                localStorage.setItem('DataTables_' + window.location.pathname, JSON.stringify(oData));
            },
            "fnStateLoad": function (oSettings) {
                var data = localStorage.getItem('DataTables_' + window.location.pathname);
                return JSON.parse(data);
            }
        });

        var tableWrapper = $('#sample_7_wrapper'); // datatable creates the table wrapper by adding with id {your_table_jd}_wrapper

        jQuery('.dataTables_filter input', tableWrapper).addClass("form-control input-small input-inline"); // modify table search input
        jQuery('.dataTables_length select', tableWrapper).addClass("form-control input-small"); // modify table per page dropdown
        jQuery('.dataTables_length select', tableWrapper).select2(); // initialize select2 dropdown
    }

    var initTable8 = function () {
        var table = $('#sample_8');

        /* Table tools samples: https://www.datatables.net/release-datatables/extras/TableTools/ */

        /* Set tabletools buttons and button container */

        $.extend(true, $.fn.DataTable.TableTools.classes, {
           
        });

        var oTable = table.dataTable({
            "aaSorting": [],
            "aLengthMenu": [
                 [10, 15, 20, -1],
                 [10, 15, 20, 'All'] // change per page values here
            ],
            // set the initial value
            "iDisplayLength": -1,
            "sDom": "<'row'><'table-scrollable't>", // horizobtal scrollable datatable

            "bStateSave": true,
            "fnStateSave": function (oSettings, oData) {
                localStorage.setItem('DataTables_' + window.location.pathname, JSON.stringify(oData));
            },
            "fnStateLoad": function (oSettings) {
                var data = localStorage.getItem('DataTables_' + window.location.pathname);
                return JSON.parse(data);
            }
        });

        var tableWrapper = $('#sample_8_wrapper'); // datatable creates the table wrapper by adding with id {your_table_jd}_wrapper

        jQuery('.dataTables_filter input', tableWrapper).addClass("form-control input-small input-inline"); // modify table search input
        jQuery('.dataTables_length select', tableWrapper).addClass("form-control input-small"); // modify table per page dropdown
        jQuery('.dataTables_length select', tableWrapper).select2(); // initialize select2 dropdown
    }

    var initTable9 = function () {
        var table = $('#sample_9');

        /* Table tools samples: https://www.datatables.net/release-datatables/extras/TableTools/ */

        /* Set tabletools buttons and button container */

        $.extend(true, $.fn.DataTable.TableTools.classes, {
            
        });

        var oTable = table.dataTable({
            "aaSorting": [],
            "aLengthMenu": [
                [10, 15, 20, -1],
                [10, 15, 20, 'All'] // change per page values here
            ],
            // set the initial value
            "iDisplayLength": -1,
            "sDom": "<'row' ><'table-scrollable't>", // horizobtal scrollable datatable

            "bStateSave": true,
            "fnStateSave": function (oSettings, oData) {
                localStorage.setItem('DataTables_' + window.location.pathname, JSON.stringify(oData));
            },
            "fnStateLoad": function (oSettings) {
                var data = localStorage.getItem('DataTables_' + window.location.pathname);
                return JSON.parse(data);
            }
        });

        var tableWrapper = $('#sample_9_wrapper'); // datatable creates the table wrapper by adding with id {your_table_jd}_wrapper

        jQuery('.dataTables_filter input', tableWrapper).addClass("form-control input-small input-inline"); // modify table search input
        jQuery('.dataTables_length select', tableWrapper).addClass("form-control input-small"); // modify table per page dropdown
        jQuery('.dataTables_length select', tableWrapper).select2(); // initialize select2 dropdown
    }

    var initTable10 = function () {
        var table = $('#sample_10');

        /* Table tools samples: https://www.datatables.net/release-datatables/extras/TableTools/ */

        /* Set tabletools buttons and button container */

        $.extend(true, $.fn.DataTable.TableTools.classes, {
           
        });

        var oTable = table.dataTable({
            "aaSorting": [],
            "aLengthMenu": [
                [10, 15, 20, -1],
                [10, 15, 20, 'All'] // change per page values here
            ],
            // set the initial value
            "iDisplayLength": -1,
            "sDom": "<'row' ><'table-scrollable't>", // horizobtal scrollable datatable

            "bStateSave": true,
            "fnStateSave": function (oSettings, oData) {
                localStorage.setItem('DataTables_' + window.location.pathname, JSON.stringify(oData));
            },
            "fnStateLoad": function (oSettings) {
                var data = localStorage.getItem('DataTables_' + window.location.pathname);
                return JSON.parse(data);
            }
        });

        var tableWrapper = $('#sample_10_wrapper'); // datatable creates the table wrapper by adding with id {your_table_jd}_wrapper

        jQuery('.dataTables_filter input', tableWrapper).addClass("form-control input-small input-inline"); // modify table search input
        jQuery('.dataTables_length select', tableWrapper).addClass("form-control input-small"); // modify table per page dropdown
        jQuery('.dataTables_length select', tableWrapper).select2(); // initialize select2 dropdown
    }
    var initTable11 = function () {
        var table = $('#sample_5');

        /* Table tools samples: https://www.datatables.net/release-datatables/extras/TableTools/ */

        /* Set tabletools buttons and button container */

        $.extend(true, $.fn.DataTable.TableTools.classes, {

        });

        var oTable = table.dataTable({
            "aaSorting": [],
            "aLengthMenu": [
                 [10, 15, 20, -1],
                 [10, 15, 20, 'All'] // change per page values here
            ],
            // set the initial value
            "iDisplayLength": -1,
            "sDom": "<'row' ><'table-scrollable't>", // horizobtal scrollable datatable

            "bStateSave": true,
            "fnStateSave": function (oSettings, oData) {
                localStorage.setItem('DataTables_' + window.location.pathname, JSON.stringify(oData));
            },
            "fnStateLoad": function (oSettings) {
                var data = localStorage.getItem('DataTables_' + window.location.pathname);
                return JSON.parse(data);
            }
        });

        var tableWrapper = $('#sample_5_wrapper'); // datatable creates the table wrapper by adding with id {your_table_jd}_wrapper

        jQuery('.dataTables_filter input', tableWrapper).addClass("form-control input-small input-inline"); // modify table search input
        jQuery('.dataTables_length select', tableWrapper).addClass("form-control input-small"); // modify table per page dropdown
        jQuery('.dataTables_length select', tableWrapper).select2(); // initialize select2 dropdown
    }


    var initTable12 = function () {
        var table = $('#sample_11');

        /* Table tools samples: https://www.datatables.net/release-datatables/extras/TableTools/ */

        /* Set tabletools buttons and button container */

        $.extend(true, $.fn.DataTable.TableTools.classes, {

        });

        var oTable = table.dataTable({
            "aaSorting": [],
            "aLengthMenu": [
                [10, 15, 20, -1],
                [10, 15, 20, 'All'] // change per page values here
            ],
            // set the initial value
            "iDisplayLength": -1,
            //"sScrollY": "200",
            //"bScrollCollapse": true,
            "sDom": "<'row'><'table-scrollable't>", // horizobtal scrollable datatable

            "bStateSave": true,
            "fnStateSave": function (oSettings, oData) {
                localStorage.setItem('DataTables_' + window.location.pathname, JSON.stringify(oData));
            },
            "fnStateLoad": function (oSettings) {
                var data = localStorage.getItem('DataTables_' + window.location.pathname);
                return JSON.parse(data);
            }
        });

        var tableWrapper = $('#sample_11_wrapper'); // datatable creates the table wrapper by adding with id {your_table_jd}_wrapper

        jQuery('.dataTables_filter input', tableWrapper).addClass("form-control input-small input-inline"); // modify table search input
        jQuery('.dataTables_length select', tableWrapper).addClass("form-control input-small"); // modify table per page dropdown
        jQuery('.dataTables_length select', tableWrapper).select2(); // initialize select2 dropdown
    }

    var initTable13 = function () {
        var table = $('#sample_12');

        /* Table tools samples: https://www.datatables.net/release-datatables/extras/TableTools/ */

        /* Set tabletools buttons and button container */

        $.extend(true, $.fn.DataTable.TableTools.classes, {

        });

        var oTable = table.dataTable({
            "aaSorting": [],
            "aLengthMenu": [
                [10, 15, 20, -1],
                [10, 15, 20, 'All'] // change per page values here
            ],
            // set the initial value
            "iDisplayLength": -1,
            //"sScrollY": "200",
            //"bScrollCollapse": true,
            "sDom": "<'row'><'table-scrollable't>", // horizobtal scrollable datatable

            "bStateSave": true,
            "fnStateSave": function (oSettings, oData) {
                localStorage.setItem('DataTables_' + window.location.pathname, JSON.stringify(oData));
            },
            "fnStateLoad": function (oSettings) {
                var data = localStorage.getItem('DataTables_' + window.location.pathname);
                return JSON.parse(data);
            }
        });

        var tableWrapper = $('#sample_12_wrapper'); // datatable creates the table wrapper by adding with id {your_table_jd}_wrapper

        jQuery('.dataTables_filter input', tableWrapper).addClass("form-control input-small input-inline"); // modify table search input
        jQuery('.dataTables_length select', tableWrapper).addClass("form-control input-small"); // modify table per page dropdown
        jQuery('.dataTables_length select', tableWrapper).select2(); // initialize select2 dropdown
    }

    var initTable14 = function () {
        var table = $('#sample_13');

        /* Table tools samples: https://www.datatables.net/release-datatables/extras/TableTools/ */

        /* Set tabletools buttons and button container */

        $.extend(true, $.fn.DataTable.TableTools.classes, {

        });

        var oTable = table.dataTable({
            "aaSorting": [],
            "aLengthMenu": [
                [10, 15, 20, -1],
                [10, 15, 20, 'All'] // change per page values here
            ],
            // set the initial value
            "iDisplayLength": -1,
            //"sScrollY": "200",
            //"bScrollCollapse": true,
            "sDom": "<'row'><'table-scrollable't>", // horizobtal scrollable datatable

            "bStateSave": true,
            "fnStateSave": function (oSettings, oData) {
                localStorage.setItem('DataTables_' + window.location.pathname, JSON.stringify(oData));
            },
            "fnStateLoad": function (oSettings) {
                var data = localStorage.getItem('DataTables_' + window.location.pathname);
                return JSON.parse(data);
            }
        });

        var tableWrapper = $('#sample_13_wrapper'); // datatable creates the table wrapper by adding with id {your_table_jd}_wrapper

        jQuery('.dataTables_filter input', tableWrapper).addClass("form-control input-small input-inline"); // modify table search input
        jQuery('.dataTables_length select', tableWrapper).addClass("form-control input-small"); // modify table per page dropdown
        jQuery('.dataTables_length select', tableWrapper).select2(); // initialize select2 dropdown
    }

    var initTable15 = function () {
        var table = $('#sample_14');

        /* Table tools samples: https://www.datatables.net/release-datatables/extras/TableTools/ */

        /* Set tabletools buttons and button container */

        $.extend(true, $.fn.DataTable.TableTools.classes, {

        });

        var oTable = table.dataTable({
            "aaSorting": [],
            "aLengthMenu": [
                [10, 15, 20, -1],
                [10, 15, 20, 'All'] // change per page values here
            ],
            // set the initial value
            "iDisplayLength": -1,
            //"sScrollY": "200",
            //"bScrollCollapse": true,
            "sDom": "<'row'><'table-scrollable't>", // horizobtal scrollable datatable

            "bStateSave": true,
            "fnStateSave": function (oSettings, oData) {
                localStorage.setItem('DataTables_' + window.location.pathname, JSON.stringify(oData));
            },
            "fnStateLoad": function (oSettings) {
                var data = localStorage.getItem('DataTables_' + window.location.pathname);
                return JSON.parse(data);
            }
        });

        var tableWrapper = $('#sample_14_wrapper'); // datatable creates the table wrapper by adding with id {your_table_jd}_wrapper

        jQuery('.dataTables_filter input', tableWrapper).addClass("form-control input-small input-inline"); // modify table search input
        jQuery('.dataTables_length select', tableWrapper).addClass("form-control input-small"); // modify table per page dropdown
        jQuery('.dataTables_length select', tableWrapper).select2(); // initialize select2 dropdown
    }

    var initTable16 = function () {
        var table = $('#sample_15');

        /* Table tools samples: https://www.datatables.net/release-datatables/extras/TableTools/ */

        /* Set tabletools buttons and button container */

        $.extend(true, $.fn.DataTable.TableTools.classes, {

        });

        var oTable = table.dataTable({
            "aaSorting": [],
            "aLengthMenu": [
                [10, 15, 20, -1],
                [10, 15, 20, 'All'] // change per page values here
            ],
            // set the initial value
            "iDisplayLength": -1,
            //"sScrollY": "200",
            //"bScrollCollapse": true,
            "sDom": "<'row'><'table-scrollable't>", // horizobtal scrollable datatable

            "bStateSave": true,
            "fnStateSave": function (oSettings, oData) {
                localStorage.setItem('DataTables_' + window.location.pathname, JSON.stringify(oData));
            },
            "fnStateLoad": function (oSettings) {
                var data = localStorage.getItem('DataTables_' + window.location.pathname);
                return JSON.parse(data);
            }
        });

        var tableWrapper = $('#sample_15_wrapper'); // datatable creates the table wrapper by adding with id {your_table_jd}_wrapper

        jQuery('.dataTables_filter input', tableWrapper).addClass("form-control input-small input-inline"); // modify table search input
        jQuery('.dataTables_length select', tableWrapper).addClass("form-control input-small"); // modify table per page dropdown
        jQuery('.dataTables_length select', tableWrapper).select2(); // initialize select2 dropdown
    }

    var initTable17 = function () {
        var table = $('#sample_16');

        /* Table tools samples: https://www.datatables.net/release-datatables/extras/TableTools/ */

        /* Set tabletools buttons and button container */

        $.extend(true, $.fn.DataTable.TableTools.classes, {

        });

        var oTable = table.dataTable({
            "aaSorting": [],
            "aLengthMenu": [
                [10, 15, 20, -1],
                [10, 15, 20, 'All'] // change per page values here
            ],
            // set the initial value
            "iDisplayLength": -1,
            //"sScrollY": "200",
            //"bScrollCollapse": true,
            "sDom": "<'row'><'table-scrollable't>", // horizobtal scrollable datatable

            "bStateSave": true,
            "fnStateSave": function (oSettings, oData) {
                localStorage.setItem('DataTables_' + window.location.pathname, JSON.stringify(oData));
            },
            "fnStateLoad": function (oSettings) {
                var data = localStorage.getItem('DataTables_' + window.location.pathname);
                return JSON.parse(data);
            }
        });

        var tableWrapper = $('#sample_16_wrapper'); // datatable creates the table wrapper by adding with id {your_table_jd}_wrapper

        jQuery('.dataTables_filter input', tableWrapper).addClass("form-control input-small input-inline"); // modify table search input
        jQuery('.dataTables_length select', tableWrapper).addClass("form-control input-small"); // modify table per page dropdown
        jQuery('.dataTables_length select', tableWrapper).select2(); // initialize select2 dropdown
    }

    var initTable18 = function () {
        var table = $('#sample_17');

        /* Table tools samples: https://www.datatables.net/release-datatables/extras/TableTools/ */

        /* Set tabletools buttons and button container */

        $.extend(true, $.fn.DataTable.TableTools.classes, {

        });

        var oTable = table.dataTable({
            "aaSorting": [],
            "aLengthMenu": [
                [10, 15, 20, -1],
                [10, 15, 20, 'All'] // change per page values here
            ],
            // set the initial value
            "iDisplayLength": -1,
            //"sScrollY": "200",
            //"bScrollCollapse": true,
            "sDom": "<'row'><'table-scrollable't>", // horizobtal scrollable datatable

            "bStateSave": true,
            "fnStateSave": function (oSettings, oData) {
                localStorage.setItem('DataTables_' + window.location.pathname, JSON.stringify(oData));
            },
            "fnStateLoad": function (oSettings) {
                var data = localStorage.getItem('DataTables_' + window.location.pathname);
                return JSON.parse(data);
            }
        });

        var tableWrapper = $('#sample_17_wrapper'); // datatable creates the table wrapper by adding with id {your_table_jd}_wrapper

        jQuery('.dataTables_filter input', tableWrapper).addClass("form-control input-small input-inline"); // modify table search input
        jQuery('.dataTables_length select', tableWrapper).addClass("form-control input-small"); // modify table per page dropdown
        jQuery('.dataTables_length select', tableWrapper).select2(); // initialize select2 dropdown
    }

    var initTable19 = function () {
        var table = $('#sample_18');

        /* Table tools samples: https://www.datatables.net/release-datatables/extras/TableTools/ */

        /* Set tabletools buttons and button container */

        $.extend(true, $.fn.DataTable.TableTools.classes, {

        });

        var oTable = table.dataTable({
            "aaSorting": [],
            "aLengthMenu": [
                [10, 15, 20, -1],
                [10, 15, 20, 'All'] // change per page values here
            ],
            // set the initial value
            "iDisplayLength": -1,
            //"sScrollY": "200",
            //"bScrollCollapse": true,
            "sDom": "<'row'><'table-scrollable't>", // horizobtal scrollable datatable

            "bStateSave": true,
            "fnStateSave": function (oSettings, oData) {
                localStorage.setItem('DataTables_' + window.location.pathname, JSON.stringify(oData));
            },
            "fnStateLoad": function (oSettings) {
                var data = localStorage.getItem('DataTables_' + window.location.pathname);
                return JSON.parse(data);
            }
        });

        var tableWrapper = $('#sample_18_wrapper'); // datatable creates the table wrapper by adding with id {your_table_jd}_wrapper

        jQuery('.dataTables_filter input', tableWrapper).addClass("form-control input-small input-inline"); // modify table search input
        jQuery('.dataTables_length select', tableWrapper).addClass("form-control input-small"); // modify table per page dropdown
        jQuery('.dataTables_length select', tableWrapper).select2(); // initialize select2 dropdown
    }

    return {

        //main function to initiate the module
        init: function () {

            if (!jQuery().dataTable) {
                return;
            }

            initTable1();
            initTable2();
            initTable3();
            initTable4();
            initTable5();
            initTable6();
            initTable7();
            initTable8();
            initTable9();
            initTable10();
            initTable11();
            initTable12();
            initTable13();
            initTable14();
            initTable15();
            initTable16();
            initTable17();
            initTable18();
            initTable19();
        }

    };

}();