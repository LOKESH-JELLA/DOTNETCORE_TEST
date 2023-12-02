//function GridViewTable(GridID) {
//    var ID = '#EstatesHomeBody_' + GridID;
//    debugger;
//$(document).ready(function () {
//    datatableFn = function () {
//        var device = getBrowserInfo(),
//            horizontalScroll = 0,
//            tableElement = $(this[0]),
//            scrollBody = $('.dataTables_scrollBody'),
//            scrollFoot = $('.dataTables_scrollFoot'),
//            maxScrollLeft,
//            start = {
//                x: 0,
//                y: 0
//            },
//            offset;

//        // Compute the maxScrollLeft value
//        tableElement.on('draw.dt', function () {
//            maxScrollLeft = tableElement.width() - scrollBody.width() + 2;
//        });

//        // Disable TBODY scoll bars
//        scrollBody.css({
//            'overflow-x': 'hidden'
//        });

//        // Enable TFOOT scoll bars
//        scrollFoot.css('overflow-x', 'auto');

//        // Sync TFOOT scrolling with TBODY
//        scrollFoot.on('scroll', function (event) {
//            horizontalScroll = scrollFoot.scrollLeft();
//            scrollBody.scrollLeft(horizontalScroll);
//        });

//        // Enable body scroll for touch devices
//        if ((device.isAndroid && !device.isChrome) || device.isiPad ||
//            (device.isMac && !device.isFF)) {
//            // Enable for TBODY scoll bars
//            scrollBody.css({
//                'overflow-x': 'auto'
//            });
//        }

//        // Fix for android chrome column misalignment on scrolling
//        if (device.isAndroid && device.isChrome) {
//            scrollBody[0].addEventListener("touchstart", touchStart, false);
//            scrollBody[0].addEventListener("touchmove", touchMove, false);
//            scrollFoot[0].addEventListener("touchstart", touchStart, false);
//            scrollFoot[0].addEventListener("touchmove", touchMoveFooter, false);
//        }

//        // Fix for Mac OS dual scrollbar problem
//        if (device.isMac && device.isFF) {
//            scrollBody.on('wheel', function (event) {
//                if (Math.abs(event.originalEvent.deltaY) < 3) {
//                    event.preventDefault();
//                }
//                performScroll(event.originalEvent.deltaX);
//            });
//        }

//        /*
//         * Performs the scroll based on the delta value supplied.
//         * @param deltaX {Number}
//         */
//        function performScroll(deltaX) {
//            horizontalScroll = horizontalScroll + deltaX;
//            if (horizontalScroll > maxScrollLeft) {
//                horizontalScroll = maxScrollLeft;
//            } else if (horizontalScroll < 0) {
//                horizontalScroll = 0;
//            }
//            scrollFoot.scrollLeft(horizontalScroll);
//        }
//        /*
//         * Computes the touch start position along with the maximum
//         * scroll left position
//         * @param e {object}
//         */
//        function touchStart(e) {
//            start.x = e.touches[0].pageX;
//            start.y = e.touches[0].pageY;
//        }
//        /*
//         * Computes the offset position and perform the scroll based
//         * on the offset
//         * @param e {Object}
//         */
//        function touchMove(e) {
//            offset = {};
//            offset.x = start.x - e.touches[0].pageX;
//            offset.y = start.y - e.touches[0].pageY;
//            performScroll(offset.x / 3);
//        }
//        /*
//         * Computes the offset position and perform the scroll based
//         * on the offset
//         * @param e {Object}
//         */
//        function touchMoveFooter(e) {
//            e.preventDefault();
//            touchMove(e);
//        }
//        /**
//         * @getBrowserInfo
//         * @description
//         * To get browser information
//         *
//         * @return {Object}
//         */
//        function getBrowserInfo() {
//            return {
//                isiPad: (/\(iPad.*os (\d+)[._](\d+)/i).test(navigator.userAgent) === true || navigator.platform
//                    .toLowerCase() === 'ipad',
//                isAndroid: (/\(*Android (\d+)[._](\d+)/i).test(navigator.userAgent),
//                isMac: navigator.platform.toUpperCase().indexOf('MAC') >= 0,
//                isChrome: !!window.chrome,
//                isFF: !!window.sidebar
//            };
//        };
//        /**
//         * @getBrowserInfo
//         * @description
//         * To get browser information
//         *
//         * @return {Object}
//         */
//        function getBrowserInfo() {
//            return {
//                isiPad: (/\(iPad.*os (\d+)[._](\d+)/i).test(navigator.userAgent) === true ||
//                    navigator.platform.toLowerCase() === 'ipad',
//                isAndroid: (/\(*Android (\d+)[._](\d+)/i).test(navigator.userAgent),
//                isMac: navigator.platform.toUpperCase().indexOf('MAC') >= 0,
//                isChrome: !!window.chrome,
//                isFF: !!window.sidebar
//            };
//        };

//        jQuery.fn.dataTable.Api.register('sum()', function () {
//            return this.flatten().reduce(function (a, b) {
//                if (typeof a === 'string') {
//                    a = a.replace(/[^\d.-]/g, '') * 1;
//                }
//                if (typeof b === 'string') {
//                    b = b.replace(/[^\d.-]/g, '') * 1;
//                }

//                return a + b;
//            }, 0);
//        });


//        function formatNumber(num, isDollars) {
//            if (num && isDollars) {
//                return `${num.toFixed(1).replace(/\B(?=(\d{3})+(?!\d))/g, ",")}`;
//            }
//            //return num;
//            return `${num.toFixed(1).replace(/\B(?=(\d{3})+(?!\d))/g, ",")}`;

//        }


//    };

//    pdl_table = $('.ghmc_table').DataTable({
//        language: {
//            search: "_INPUT_",
//            searchPlaceholder: "Search records here",
//            //info: " _PAGE_ of _PAGES_ pages",
//            sPaginationType: "",
//            lengthMenu: "Items per page: _MENU_ ",
//            paginate: {
//                previous: '<i class="fa fa-chevron-left"></i>',
//                next: '<i class="fa fa-chevron-right"></i>'
//            },
//            aria: {
//                paginate: {
//                    previous: 'Previous',
//                    next: 'Next'
//                }
//            }

//        },
//        "dom": "<'table-wrapper clearfix top'<'row d-flex'<'col-sm-8 dt-left-side d-flex'Bf><'col-sm-4 text-right dt-right-side'li | >>>t<' bottom'<'row'<'col-sm-4' | ><'col-sm-4'p>>>",
//        "autoWidth": true,
//        "responsive": false,
//        paging: true,

//        //"columnDefs": [
//        //    // { "visible": false, "targets": [0, 1, 2, 3, 4, 5] }
//        //    { "visible": true, "aTargets": [0, 1, 2, 3, 4, 5, 6, 7, 8] },
//        //    { "visible": false, "aTargets": ['_all'] }
//        //],

//        "scrollX": true,
//        //scrollY:  "calc(100vh - 380px)",
//        scrollY: "50vh",
//        scrollCollapse: true,
//        lengthChange: false,
//        lengthMenu: [
//            [10, 25, 50, -1],
//            [10, 25, 50, "All"]
//        ],

//        fixedHeader: {
//            header: false,
//            footer: false
//        },
//        //fnInitComplete: datatableFn,
//        deferRender: true,
//        buttons: [

//            {
//                extend: 'colvis',
//                text: '<i class="fa fa-list" aria-hidden="true"></i> ',
//                titleAttr: 'show/hide column',
//                columns: ':gt(0)'
//            },
//            {
//                extend: 'excelHtml5',
//                className: 'btn ',
//                text: '<i class="far fa-file-excel"></i>  Excel',
//                title: "Sample_File_name",
//                fileName: "Sample_File_name",
//                titleAttr: 'Excel Export',
//                footer: true,
//                exportOptions: {
//                    columns: [':visible :not(:last-child)']
//                    //columns: ':visible:not(.not-export-col)'
//                }
//            },
//            {
//                extend: 'pdfHtml5',
//                className: 'btn ',
//                text: '<i class="far fa-file-pdf"></i> PDF',
//                title: "Sample_File_name",
//                fileName: "Sample_File_name",
//                titleAttr: 'PDF Export',
//                footer: true,
//                pageSize: "A4",
//                exportOptions: {
//                    columns: [':visible :not(:last-child)']
//                    //columns: [0, ':visible:not(.not-export-col)']
//                },

//            },
//            {
//                extend: 'print',
//                className: 'btn  ',
//                text: '<i class="fa fa-print"></i> Print',
//                title: "Tenant Details",
//                fileName: "Sample_File_name",
//                titleAttr: 'Print',
//                autoPrint: true,
//                customize: function (win) {

//                    $(win.document.body)
//                        .css('font-size', '12px').prepend('');

//                    $(win.document.body).find('table')
//                        .addClass('compact')
//                        .css('font-size', 'inherit');

//                    $(win.document).find('title ').empty();
//                },
//                footer: true,
//                exportOptions: {
//                    columns: [':visible :not(:last-child)']
//                    //columns: [0, ':visible:not(.not-export-col)']
//                }
//            }
//        ]
//        //,
//        //"footerCallback": function (row, data, start, end, display) {
//        //    var api = this.api();
//        //    var intVal = function (i) {
//        //        return typeof i === "string"
//        //            ? i.replace(/[\$,]/g, "") * 1
//        //            : typeof i === "number"
//        //                ? i
//        //                : 0;
//        //    };
//        //    nb_cols = api.columns().nodes().length;
//        //    var j = 2;
//        //    while (j < nb_cols) {
//        //        var pageTotal = api
//        //            .column(j, { page: 'current' })
//        //            .data()
//        //            .reduce(function (a, b) {
//        //                var b2 = $("<div />")
//        //                    .html(b)
//        //                    .text();
//        //                return intVal(a) + intVal(b2);
//        //                //return Number(a) + Number(b2);

//        //            }, 0);
//        //        // Update footer
//        //        $(api.column(j).footer()).html(formatNumber(pageTotal));
//        //        j++;
//        //    }
//        //}
//    });
//    // end

//    setTimeout(function () {
//        pdl_table.columns.adjust().draw();

//    }, 100);
//    $('[data-widget="pushmenu"]').on('click', function () {

//        setTimeout(function () {
//            pdl_table.columns.adjust().draw();
//        }, 500);
//    });
//    $(window).resize(function () {

//        setTimeout(function () {
//            pdl_table.columns.adjust().draw();
//        }, 100);
//    });
    
//});

$(function () {
    ghmc_table1(); // bind data table on first page load
    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(ghmc_table1); // bind data table on every UpdatePanel refresh
});

function ghmc_table1() {

    let current_datetime = new Date()
    let formatted_date = current_datetime.getDate() + "-" + (current_datetime.getMonth() + 1) + "-" + current_datetime.getFullYear()  + "  " + current_datetime.getHours() + ":" + current_datetime.getMinutes() + ":" + current_datetime.getSeconds()
   

pdl_table = $('.ghmc_table').DataTable({
        language: {
            search: "_INPUT_",
            searchPlaceholder: "Search records here",
            //info: " _PAGE_ of _PAGES_ pages",
            sPaginationType: "",
            //lengthMenu: "Items per page: _MENU_ ",
            paginate: {
                previous: '<i class="fa fa-chevron-left"></i>',
                next: '<i class="fa fa-chevron-right"></i>'
            },
            aria: {
                paginate: {
                    previous: 'Previous',
                    next: 'Next'
                }
            }

        },
        //"dom": "<'table-wrapper clearfix top'<'row d-flex'<'col-sm-8 dt-left-side d-flex'Bf><'col-sm-4 text-right dt-right-side'li | >>>t<' bottom'<'row'<'col-sm-4' | ><'col-sm-4'p>>>",
        "dom": "<'table-wrapper clearfix top'<'row d-flex'<'col-md-8 dt-left-side d-flex'Bf><'col-md-4 text-right dt-right-side d-flex justify-content-end align-items-end 'l >>><'w-100' t><' bottom'<'row'<'col-sm-6 text-align-left' i | ><'col-sm-6' p>>>",
        "autoWidth": true,
        "responsive": false,
        paging: true,

        //"columnDefs": [
        //    // { "visible": false, "targets": [0, 1, 2, 3, 4, 5] }
        //    { "visible": true, "aTargets": [0, 1, 2, 3, 4, 5, 6, 7, 8] },
        //    { "visible": false, "aTargets": ['_all'] }
        //],

    //"scrollX": false,
        //scrollY:  "calc(100vh - 380px)",
      //  scrollY: "50vh",
        "scrollX": true,
        //scrollY: "calc(100vh - 380px)",
        scrollY: "50vh",
        scrollCollapse: true,
        lengthChange: true,
        lengthMenu: [
            [10, 25, 50, -1],
            [10, 25, 50, "All"]
        ],

        fixedHeader: {
            header: false,
            footer: false
        },
        //fnInitComplete: datatableFn,
        deferRender: true,
        buttons: [

            {
                extend: 'colvis',
                text: '<i class="fa fa-list" aria-hidden="true"></i> ',
                titleAttr: 'show/hide column',
                columns: ':gt(0)'
            },
            {
                extend: 'excelHtml5',
                className: 'btn ',
                text: '<i class="far fa-file-excel"></i>  Excel',
                title: "DETAILS OF PLOTS/LAYOUTS APPLIED FOR REGULARIZATION  " + formatted_date +""+"  Amount Rs. in Lakhs & Area in Sq.Yards",
                fileName: "DETAILS OF PLOTS/LAYOUTS APPLIED FOR REGULARIZATION",
                titleAttr: 'Excel Export',
                footer: true,
                exportOptions: {
                    //columns: [':visible :not(:last-child)']
                    columns: ':visible:not(.not-export-col)'
                }
            },
            {
                extend: 'pdfHtml5',
                className: 'btn ',
                text: '<i class="far fa-file-pdf"></i> PDF',
                title: "DETAILS OF PLOTS/LAYOUTS APPLIED FOR REGULARIZATION  " + formatted_date + "                           "+"Amount Rs. in Lakhs & Area in Sq.Yards",
                fileName: "DETAILS OF PLOTS/LAYOUTS APPLIED FOR REGULARIZATION",
                titleAttr: 'PDF Export',
                footer: true,
                pageSize: "A2",
                exportOptions: {
                    //columns: [':visible :not(:last-child)']
                    columns: [0, ':visible:not(.not-export-col)']
                },

            },
            {
                extend: 'print',
                className: 'btn  ',
                text: '<i class="fa fa-print"></i> Print',
                title: "DETAILS OF PLOTS/LAYOUTS APPLIED FOR REGULARIZATION <br> <label text-align: 'left'><font color='red' size='4px' text-align='left'> " + formatted_date + "</font></label> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<label text-align='right'><font color='red' size='4px' text-align='right'>Amount Rs. in Lakhs & Area in Sq.Yards </font></label>",
                fileName: "DETAILS OF PLOTS/LAYOUTS APPLIED FOR REGULARIZATION",
                titleAttr: 'Print',
                autoPrint: true,
                customize: function (win) {

                    $(win.document.body)
                        .css('font-size', '12px').prepend('');

                    $(win.document.body).find('table')
                        .addClass('compact')
                        .css('font-size', 'inherit');

                    $(win.document).find('title ').empty();
                },
                footer: true,
                exportOptions: {
                    //columns: [':visible :not(:last-child)']
                    columns: [0, ':visible:not(.not-export-col)']
                }
            }
        ]
    });
    // end

    setTimeout(function () {
        pdl_table.columns.adjust().draw();

    }, 100);
    $('[data-widget="pushmenu"]').on('click', function () {

        setTimeout(function () {
            pdl_table.columns.adjust().draw();
        }, 500);
    })
    $(window).resize(function () {

        setTimeout(function () {
            pdl_table.columns.adjust().draw();
        }, 100);
    });
}


