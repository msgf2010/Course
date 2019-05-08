$(() => {
    $("#pending-ppl-table").on('click', '.confirm', function () {
        $("#pending-ppl-table").find("tr:gt(0)").remove();
        const id = $(this).data('confirmid');
        $.post('/candidates/ConfirmPerson', { Id: id }, function (people) {
            people.forEach(addPeopleToTable);
            updateNavbar();
        });
    });

    $("#pending-ppl-table").on('click', '.decline', function () {
        $("#pending-ppl-table").find("tr:gt(0)").remove();
        const id = $(this).data('declineid');
        $.post('/candidates/DeclinePerson', { Id: id }, function (people) {
            people.forEach(addPeopleToTable);
            updateNavbar();
        });
    });

    const updateNavbar = () => {
        $.get('/candidates/CandidatesStatus', result => {
            $("#layout-pending").text(`Pending (${result.pendingPpl})`);
            $("#layout-confirmed").text(`Confirmed (${result.confirmedPpl})`);
            $("#layout-declined").text(`Declined (${result.declinedPpl})`);
        });
    };

    $('#toggle-notes').on('click', function () {
        $('.notes').toggle();
    });

    const addPeopleToTable = people => {
        $("#pending-ppl-table").append
            (`<tr>
                <td>${people.firstName}</td>
                <td>${people.lastName}</td>
                <td>${people.phoneNumber}</td>
                <td>${people.email}</td>
                <td>${people.notes}</td>
                <td>
                    <button id="confirm-btn"
                            data-confirmid="${people.id}"
                            class="btn btn-success confirm">
                        Confirm
                    </button>
                    <button id="decline-btn"
                            data-declineid="${people.id}"
                            class="btn btn-danger decline">
                        Decline
                    </button>
                </td>
            </tr>`);
    }
});