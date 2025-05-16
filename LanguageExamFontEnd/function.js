var dateFormat = function() {
    $('.type-date').datepicker({
        format: "dd/mm/yyyy",
        language: "vi",
        orientation: "bottom auto",
        endDate: '+0d',
        autoclose: true,
    });
}

function formatDate(input) {
            const parts = input.split('-'); // ['0001', '01', '01']
            const year = parts[0];
            const month = parts[1];
            const day = parts[2];

            return `${day}-${month}-${year}`; // '01-01-0001'
        }