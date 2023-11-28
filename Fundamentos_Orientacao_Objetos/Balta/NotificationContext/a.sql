SELECT  (CASE WHEN Co.CodigoConvenio IS NULL THEN 1 ELSE 2 END) AS Tipo
       ,FVF.Valor                                               AS Total
FROM Financeiro_Valor_Fluxo AS FVF
INNER JOIN Financeiro_Valor AS FV
ON FVF.CodigoValor = FV.CodigoValor
INNER JOIN Financeiro AS F
ON FV.CodigoFinanceiro = F.CodigoFinanceiro
INNER JOIN Financeiro AS FI
ON FVF.CodigoLancamento = FI.CodigoLancamento
INNER JOIN Financeiro_Valor AS FVI
ON FI.CodigoFinanceiro = FVI.CodigoFinanceiro
LEFT JOIN Convenio AS CO
ON FI.CodigoCadastro = CO.CodigoCadastro
WHERE FV.CodigoConta = @CodigoContaReceber
AND FI.DataLancamento BETWEEN @DataInicial AND @DataFinal
AND FI.CodigoEmpresa = @CodigoEmpresa
AND F.Eliminado = @Eliminado
AND FI.Eliminado = @Eliminado
AND FVF.CodigoGrupo = @CodigoGrupo
GROUP BY  (CASE WHEN Co.CodigoConvenio IS NULL THEN 1 ELSE 2 END)
         ,FVF.Valor
         ,FVF.CodigoValor
         ,F.CodigoCadastro
         ,FVF.CodigoLancamento',N'@CodigoContaReceber int
         ,@DataInicial datetime
         ,@DataFinal datetime
         ,@CodigoEmpresa int
         ,@Eliminado bit
         ,@CodigoGrupo int',@CodigoContaReceber=2,@DataInicial='2023-11-27 00:00:00',@DataFinal='2023-11-27 23:59:00',@CodigoEmpresa = 1,@Eliminado = 0,@CodigoGrupo = 5