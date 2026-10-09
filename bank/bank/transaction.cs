namespace bank
{
    /// <summary>
    /// Представляет одну банковскую операцию: сумму, дату и текстовый комментарий.
    /// </summary>
    /// <param name="Amount">Сумма операции. Положительная — пополнение, отрицательная — списание.</param>
    /// <param name="Date">Дата и время совершения операции (в UTC).</param>
    /// <param name="Note">Произвольный комментарий к операции.</param>
    public record transaction(decimal Amount, DateTime date, string note)
    {

    }
}
